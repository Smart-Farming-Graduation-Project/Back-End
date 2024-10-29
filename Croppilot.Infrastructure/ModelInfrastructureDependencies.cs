using Croppilot.Infrastructure.Repositories.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Croppilot.Infrastructure
{
    public static class ModelInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection service)
        {
            // service.AddTransient(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();

            return service;
        }
    }
}
