using Croppilot.Core.Bases;
using Microsoft.Azure.Cosmos;
using System.Security.Claims;
using System.Text.Json.Serialization;
using WatchDog;
using WatchDog.src.Enums;
using Enum = System.Enum;

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

        services.AddHttpContextAccessor().AddSwaggerServices().AddRolePolicy().AddCorSServices()
            .AddWatchDogConfigurations(configuration);


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
}
