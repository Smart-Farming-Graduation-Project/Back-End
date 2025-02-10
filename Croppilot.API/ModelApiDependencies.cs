using Croppilot.Date.Enum;
using System.Security.Claims;

namespace Croppilot.API;

public static class ModelApiDependencies
{
	public static IServiceCollection AddApiDependencies(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddSwaggerServices().AddCorSServices();
		services.AddRolePolicy();
		services.AddHttpContextAccessor();

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
}