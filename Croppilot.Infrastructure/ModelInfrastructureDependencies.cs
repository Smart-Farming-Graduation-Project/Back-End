using Croppilot.Date.Helpers;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Repositories.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Croppilot.Infrastructure
{
	public static class ModelInfrastructureDependencies
	{
		public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service,
			IConfiguration confg)
		{
			// service.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
			service.AddTransient<IProductRepository, ProductRepository>();
			service.AddTransient<ICategoryRepository, CategoryRepository>();
			service.AddTransient<IUnitOfWork, UnitOfWork>();
			service.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
			service.AddTransient<IOrderRepository, OrderRepository>();
			service.AddTransient<IOrderItemRepository, OrderItemRepository>();
			service.AddTransient<ICartRepository, CartRepository>();

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

			#endregion

			#region swagger Gn

			service.AddSwaggerGen(options =>
			{
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
	}
}