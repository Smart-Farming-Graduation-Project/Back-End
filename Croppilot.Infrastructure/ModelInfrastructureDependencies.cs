﻿using Croppilot.Date.Helpers;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Repositories.Implementation;
using Croppilot.Infrastructure.Repositories.Implementation.AiRepository;
using Croppilot.Infrastructure.Repositories.Implementation.Dashbored;
using Croppilot.Infrastructure.Repositories.Interfaces.AiRepository;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System.Text;

namespace Croppilot.Infrastructure
{
    public static class ModelInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service,
            IConfiguration confg)
        {
            service.AddHangfireConfigurations(confg)
                .AddRedisConfigurations(confg);

            // service.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            service.AddTransient<IOrderRepository, OrderRepository>();
            service.AddTransient<ICartRepository, CartRepository>();
            service.AddTransient<IWishlistRepository, WishlistRepository>();
            service.AddTransient<IReviewRepository, ReviewRepository>();
            service.AddTransient<IChatRepository, ChatRepository>();
            service.AddTransient<IPostRepository, PostRepository>();
            service.AddTransient<ICommentRepository, CommentRepository>();
            service.AddTransient<IVoteRepository, VoteRepository>();
            service.AddTransient<IModelRepository, ModelRepository>();
            service.AddTransient<IFeedbackRepository, FeedbackRepository>();
            service.AddTransient<IRoverRepository, RoverRepository>();
            service.AddTransient<ICuponRepository, CuponRepository>();

            service.AddTransient<IWeatherDataRepository, WeatherDataRepository>();
            service.AddTransient<IWeatherForcastRepository, WeatherForcastRepository>();
            service.AddTransient<IFieldRepository, FieldRepository>();
            service.AddTransient<IEquipmentRepository, EquipmentRepository>();
            service.AddTransient<ISoilRepository, SoilRepository>();
            service.AddTransient<IAlertsRepository, AlertsRepository>();

            #region Identity Service

            service.AddIdentityCore<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    // Password settings.
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;
                    // User settings.
                    options.User.AllowedUserNameCharacters =
                        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;
                }).AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            #endregion

            #region JWTservice

            var jwtSettings = new JwtSettings();
            confg.GetSection(nameof(JwtSettings)).Bind(jwtSettings);
            service.AddSingleton(jwtSettings);

            service.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = jwtSettings.ValidateIssuer,
                        ValidIssuers = new[] { jwtSettings.Issuer },
                        ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
                        ValidateAudience = jwtSettings.ValidateAudience,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            //Do not use this in production or devlopment for now
            //// Add Google Authentication
            //.AddGoogle(options =>
            //{
            //    options.ClientId = confg["Authentication:Google:ClientId"];
            //    options.ClientSecret = confg["Authentication:Google:ClientSecret"];
            //})
            //// Add Facebook Authentication
            //.AddFacebook(options =>
            //{
            //    options.AppId = confg["Authentication:Facebook:AppId"];
            //    options.AppSecret = confg["Authentication:Facebook:AppSecret"];
            //});

            #endregion

            #region swagger Gn

            service.AddSwaggerGen(options =>
            {
                //Add Swagger Configuration For Documentation
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Croppilot API",
                    Version = "v1",
                    Description = "**API Documentation for Croppilot**"
                });
                // Enable annotations for Swagger
                options.EnableAnnotations();
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                        "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                        "Example: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            #endregion


            return service;
        }

        private static IServiceCollection AddHangfireConfigurations(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHangfire(c => c
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));

            services.AddHangfireServer();

            return services;
        }

        private static IServiceCollection AddRedisConfigurations(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Configure Redis settings
            var redisSettings = new RedisSettings();
            configuration.GetSection("Redis").Bind(redisSettings);
            services.Configure<RedisSettings>(configuration.GetSection("Redis"));

            // Add Redis connection
            services.AddSingleton<IConnectionMultiplexer>(provider =>
            {
                try
                {
                    var connectionString = redisSettings.ConnectionString;
                    var options = ConfigurationOptions.Parse(connectionString);
                    options.AbortOnConnectFail = false; // Don't crash on connection failure
                    return ConnectionMultiplexer.Connect(connectionString);
                }
                catch (Exception ex)
                {
                    var logger = provider.GetService<ILogger<IConnectionMultiplexer>>();
                    logger?.LogError(ex, "Failed to connect to Redis. Caching will be disabled.");
                    return null!; // Allow graceful degradation
                }
            });

            // Add distributed cache using Redis
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisSettings.ConnectionString;
                options.InstanceName = redisSettings.InstanceName;
            });

            return services;
        }
    }
}