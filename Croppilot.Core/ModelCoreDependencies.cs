using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Croppilot.Core.Exceptions;

namespace Croppilot.Core
{
	public static class ModelCoreDependencies
	{
		public static IServiceCollection AddCoreDependencies(this IServiceCollection service)
		{
			service.AddMediatR(con => con.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			service.AddExceptionHandler<GlobalExceptionHandler>();
            service.AddProblemDetails();
            
            //When you use Automapper Uncomment this code

			service.AddAutoMapper(Assembly.GetExecutingAssembly());

			////When you use Validators Uncomment this code

			//service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			return service;
		}
	}
}
