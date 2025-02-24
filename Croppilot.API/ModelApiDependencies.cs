using System.Security.Claims;
using System.Text.Json.Serialization;
using WatchDog;
using WatchDog.src.Enums;

namespace Croppilot.API;

public static class ModelApiDependencies
{
    public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        services.AddHttpContextAccessor().AddSwaggerServices().AddRolePolicy().AddCorSServices()
            .AddWatchDogConfigurations(configuration);

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
            //o.AddPolicy(UserRoleEnum.Admin.ToString(), policy => policy.RequireClaim(nameof(ClaimTypes.Role), UserRoleEnum.Admin.ToString()));
            //o.AddPolicy(UserRoleEnum.User.ToString(), policy => policy.RequireClaim(nameof(ClaimTypes.Role), UserRoleEnum.User.ToString()));
        });
        return services;
    }

    private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    private static IServiceCollection AddCorSServices(this IServiceCollection services)
    {
        //todo: modify it later to add specific origins

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