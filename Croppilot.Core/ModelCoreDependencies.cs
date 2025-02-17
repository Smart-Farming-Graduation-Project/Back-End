using Croppilot.Core.Beheviors;
using Croppilot.Core.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Croppilot.Core;

public static class ModelCoreDependencies
{
    public static IServiceCollection AddCoreDependencies(this IServiceCollection service)
    {
        service.AddMediatR(con => con.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        service.AddFluentValidationServices().AddMapsterServices().AddGlobalExceptionHandlingServices();

        return service;
    }

    private static IServiceCollection AddFluentValidationServices(this IServiceCollection service)
    {
        service.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        //service.AddFluentValidationAutoValidation();
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidtorBehevior<,>));

        return service;
    }

    private static IServiceCollection AddMapsterServices(this IServiceCollection service)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        service.AddSingleton<IMapper>(new Mapper(config));

        return service;
    }

    private static IServiceCollection AddGlobalExceptionHandlingServices(this IServiceCollection service)
    {
        service.AddExceptionHandler<GlobalExceptionHandler>();
        service.AddProblemDetails();

        return service;
    }
}