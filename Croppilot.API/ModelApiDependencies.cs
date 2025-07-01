using Croppilot.Core.Bases;
using Microsoft.Azure.Cosmos;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.RateLimiting;
using WatchDog;
using WatchDog.src.Enums;
using Enum = System.Enum;
using Croppilot.Infrastructure.HealthChecks.Extensions;

namespace Croppilot.API;

public static class ModelApiDependencies
{
    public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options =>
            {
                // Cache Profiles
                options.CacheProfiles.Add("Default", new CacheProfile
                {
                    Duration = 30,
                    Location = ResponseCacheLocation.Any
                });

                options.CacheProfiles.Add("NoCache", new CacheProfile
                {
                    NoStore = true,
                    Location = ResponseCacheLocation.None
                });

                options.CacheProfiles.Add("LongCache", new CacheProfile
                {
                    Duration = 300,
                    Location = ResponseCacheLocation.Client
                });
                options.CacheProfiles.Add("OneDayCache", new CacheProfile
                {
                    Duration = 86400, // 60 * 60 * 24 = 86400 seconds = 1 day
                    Location = ResponseCacheLocation.Client
                });

                options.CacheProfiles.Add("FiveDayCache", new CacheProfile
                {
                    Duration = 432000, // 60 * 60 * 24 * 5 = 432000 seconds = 5 days
                    Location = ResponseCacheLocation.Client
                });
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Converters.Add(new HttpStatusCodeConverter());
                options.JsonSerializerOptions.WriteIndented = true;
            })
            .AddXmlSerializerFormatters();

        services.AddHttpContextAccessor().AddSwaggerServices()
            .AddRolePolicy().AddCorSServices().AddHealthChecksConfigurations(configuration)
            .AddWatchDogConfigurations(configuration);
        //.AddRateLimitConfigurations();


        services.AddSingleton<CosmosClient>(sp =>
        {
            var endpointUri = configuration["AzureService:CosmosDb:EndpointUri"];
            var primaryKey = configuration["AzureService:CosmosDb:PrimaryKey"];

            return new CosmosClient(endpointUri, primaryKey);
        });

        return services;
    }

    private static IServiceCollection AddRolePolicy(this IServiceCollection services)
    {
        services.AddAuthorization(o =>
        {
            foreach (var role in Enum.GetNames(typeof(UserRoleEnum)))
            {
                o.AddPolicy(role, policy => policy.RequireClaim(nameof(ClaimTypes.Role), role));
            }
        });
        return services;
    }

    private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    private static IServiceCollection AddCorSServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        return services;
    }

    private static IServiceCollection AddWatchDogConfigurations(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddWatchDogServices(opt =>
        {
            opt.IsAutoClear = true;
            opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Daily;
            opt.SetExternalDbConnString = configuration.GetConnectionString("WatchDog");
            opt.DbDriverOption = WatchDogDbDriverEnum.MSSQL;
        });

        return services;
    }


    private static IServiceCollection AddHealthChecksConfigurations(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHealthChecks()
            // Database checks
            .AddSqlServer(name: "Main Database",
                connectionString: configuration.GetConnectionString("Default")!,
                tags: ["Database"])
            .AddSqlServer(name: "WatchDog Database",
                connectionString: configuration.GetConnectionString("WatchDog")!,
                tags: ["Database"])
            .AddSqlServer(name: "Hangfire Database",
                connectionString: configuration.GetConnectionString("HangfireConnection")!,
                tags: ["Database"])
            .AddUrlGroup(
                new Uri("https://api.openweathermap.org/data/2.5/weather?q=Cairo&appid=" +
                        configuration["WeatherApi:ApiKey"]),
                name: "OpenWeather API",
                tags: ["External API"])

            // Background Services
            .AddHangfire(options =>
            {
                options.MaximumJobsFailed = 7;
                options.MinimumAvailableServers = 1;
            });

        services.AddCustomHealthChecks(configuration);

        return services;
    }

    private static IServiceCollection AddRateLimitConfigurations(this IServiceCollection services)
    {
        services.AddRateLimiter(rateLimiterOptions =>
        {
            rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            // Global fallback limiter
            rateLimiterOptions.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(_ =>
                RateLimitPartition.GetConcurrencyLimiter(
                    partitionKey: "GlobalLimit",
                    factory: _ => new ConcurrencyLimiterOptions
                    {
                        PermitLimit = 2000, // Max concurrent requests
                        QueueLimit = 500, // Max queued requests
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst
                    }));


            // General IP-based rate limit for anonymous users
            rateLimiterOptions.AddPolicy(RateLimiters.IpRateLimit, httpContext =>
            {
                var clientIp = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: clientIp,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 20,
                        Window = TimeSpan.FromMinutes(1),
                        SegmentsPerWindow = 6,
                        AutoReplenishment = true
                    });
            });

            // User-specific rate limiting for authenticated users
            rateLimiterOptions.AddPolicy(RateLimiters.UserIdRateLimit, httpContext =>
            {
                var userId = httpContext.User.GetUserId() ?? "anonymous";
                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: userId,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 40,
                        Window = TimeSpan.FromSeconds(60),
                        SegmentsPerWindow = 6,
                        AutoReplenishment = true
                    });
            });

            // AI Model prediction endpoints
            rateLimiterOptions.AddPolicy(RateLimiters.AIModelRateLimit, httpContext =>
            {
                var isAuthenticated = httpContext.User.Identity?.IsAuthenticated == true;

                var key = isAuthenticated
                    ? $"user_{httpContext.User.GetUserId()}"
                    : $"ip_{httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous"}";

                // Different limits for authenticated vs anonymous users
                if (isAuthenticated)
                {
                    return RateLimitPartition.GetSlidingWindowLimiter(
                        partitionKey: key,
                        factory: _ => new SlidingWindowRateLimiterOptions
                        {
                            PermitLimit = 20,
                            Window = TimeSpan.FromMinutes(5),
                            SegmentsPerWindow = 5,
                            QueueLimit = 2,
                            AutoReplenishment = true
                        });
                }

                // For anonymous users
                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: key,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 5,
                        Window = TimeSpan.FromMinutes(5),
                        SegmentsPerWindow = 5,
                        QueueLimit = 2,
                        AutoReplenishment = true
                    });
            });

            // Authentication endpoints - prevent brute force attempts
            rateLimiterOptions.AddPolicy(RateLimiters.AuthenticationEndpointsLimit, httpContext =>
            {
                var clientIp = httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous";

                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: clientIp,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 5,
                        Window = TimeSpan.FromMinutes(3),
                        SegmentsPerWindow = 6,
                        QueueLimit = 0,
                        AutoReplenishment = true
                    });
            });

            // Read operations (GET requests) - higher limits
            rateLimiterOptions.AddPolicy(RateLimiters.ReadOperationsLimit, httpContext =>
            {
                var key = httpContext.User.Identity?.IsAuthenticated == true
                    ? httpContext.User.GetUserId()
                    : httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous";

                // Different limits for authenticated vs anonymous users
                if (httpContext.User.Identity?.IsAuthenticated == true)
                {
                    return RateLimitPartition.GetSlidingWindowLimiter(
                        partitionKey: key,
                        factory: _ => new SlidingWindowRateLimiterOptions
                        {
                            PermitLimit = 20,
                            Window = TimeSpan.FromMinutes(1),
                            SegmentsPerWindow = 6,
                            AutoReplenishment = true
                        });
                }

                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: key,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 10,
                        Window = TimeSpan.FromMinutes(1),
                        SegmentsPerWindow = 6,
                        AutoReplenishment = true
                    });
            });

            // Write operations (POST/PUT/DELETE) - lower limits
            rateLimiterOptions.AddPolicy(RateLimiters.WriteOperationsLimit, httpContext =>
            {
                var key = httpContext.User.Identity?.IsAuthenticated == true
                    ? httpContext.User.GetUserId()
                    : httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous";

                // Different limits for authenticated vs anonymous users
                if (httpContext.User.Identity?.IsAuthenticated == true)
                {
                    return RateLimitPartition.GetSlidingWindowLimiter(
                        partitionKey: key,
                        factory: _ => new SlidingWindowRateLimiterOptions
                        {
                            PermitLimit = 10,
                            Window = TimeSpan.FromMinutes(1),
                            SegmentsPerWindow = 6,
                            AutoReplenishment = true
                        });
                }

                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: key,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 5,
                        Window = TimeSpan.FromMinutes(1),
                        SegmentsPerWindow = 6,
                        AutoReplenishment = true
                    });
            });

            // Payment and financial operations - highly restricted
            rateLimiterOptions.AddPolicy(RateLimiters.PaymentEndpointsLimit, httpContext =>
            {
                var clientId = httpContext.User.Identity?.IsAuthenticated == true
                    ? httpContext.User.GetUserId() ?? "unknown-user"
                    : httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous";

                return RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: clientId,
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 10,
                        Window = TimeSpan.FromMinutes(10),
                        QueueLimit = 0,
                        AutoReplenishment = true
                    });
            });

            // Social media operations (posts, comments, likes)
            rateLimiterOptions.AddPolicy(RateLimiters.SocialEndpointsLimit, httpContext =>
            {
                var userId = httpContext.User.GetUserId() ?? "anonymous";
                var method = httpContext.Request.Method.ToUpper();

                // Read operations get higher limits
                if (method == "GET")
                {
                    return RateLimitPartition.GetSlidingWindowLimiter(
                        partitionKey: userId,
                        factory: _ => new SlidingWindowRateLimiterOptions
                        {
                            PermitLimit = 100,
                            Window = TimeSpan.FromMinutes(1),
                            SegmentsPerWindow = 6,
                            AutoReplenishment = true
                        });
                }

                // Write operations (posting, commenting) get lower limits
                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: userId,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 20,
                        Window = TimeSpan.FromSeconds(90),
                        SegmentsPerWindow = 6,
                        AutoReplenishment = true
                    });
            });

            // Admin operations
            rateLimiterOptions.AddPolicy(RateLimiters.AdminEndpointsLimit, httpContext =>
            {
                var userId = httpContext.User.GetUserId() ?? "anonymous";

                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: userId,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 50,
                        Window = TimeSpan.FromMinutes(1),
                        SegmentsPerWindow = 6,
                        AutoReplenishment = true
                    });
            });

            // IoT endpoints 
            rateLimiterOptions.AddPolicy(RateLimiters.IoTEndpointsLimit, httpContext =>
            {
                var clientId = httpContext.User.Identity?.IsAuthenticated == true
                    ? httpContext.User.GetUserId() ?? "unknown-user"
                    : httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous";

                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: clientId,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 120,
                        Window = TimeSpan.FromMinutes(1),
                        SegmentsPerWindow = 6,
                        AutoReplenishment = true
                    });
            });

            // ChatBot endpoints 
            rateLimiterOptions.AddPolicy(RateLimiters.ChatBotEndpointsLimit, httpContext =>
            {
                var clientId = httpContext.User.Identity?.IsAuthenticated == true
                    ? httpContext.User.GetUserId() ?? "unknown-user"
                    : httpContext.Connection.RemoteIpAddress?.ToString() ?? "anonymous";

                return RateLimitPartition.GetSlidingWindowLimiter(
                    partitionKey: clientId,
                    factory: _ => new SlidingWindowRateLimiterOptions
                    {
                        PermitLimit = 30,
                        Window = TimeSpan.FromMinutes(1),
                        SegmentsPerWindow = 6,
                        AutoReplenishment = true
                    });
            });

            rateLimiterOptions.OnRejected = async (context, token) =>
            {
                // Set status code and content type
                context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                context.HttpContext.Response.ContentType = "application/json";

                // Get logger and log the rate limit hit
                var logger = context.HttpContext.RequestServices.GetService<ILogger>();
                logger?.LogWarning(
                    "Rate limit exceeded. IP: {IP}, Endpoint: {Endpoint}",
                    context.HttpContext.Connection.RemoteIpAddress,
                    context.HttpContext.Request.Path
                );

                // Create response json
                await context.HttpContext.Response.WriteAsJsonAsync(new
                {
                    status = 429,
                    title = "Too many requests",
                    detail = "You have exceeded the rate limit. Please try again later.",
                }, token);
            };
        });

        return services;
    }
}