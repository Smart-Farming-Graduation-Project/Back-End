using Croppilot.Infrastructure.Generics.Implementation;
using Croppilot.Infrastructure.Generics.Interfaces;
using Croppilot.Infrastructure.Repositories.Implementation;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Croppilot.Infrastructure
{
    public static class ModelInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            service.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            service.AddTransient<IProductRepository, ProductRepository>();
            return service;
        }
    }
}
