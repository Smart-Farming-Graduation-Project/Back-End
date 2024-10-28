using Microsoft.Extensions.DependencyInjection;

namespace Croppilot.Core
{
    public static class ModelCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection service)
        {
            service.AddMediatR(con => con.RegisterServicesFromAssembly(typeof(ModelCoreDependencies).Assembly));

            return service;
        }
    }
}
