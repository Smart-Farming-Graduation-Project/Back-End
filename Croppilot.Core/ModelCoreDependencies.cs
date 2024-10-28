using Croppilot.Core.Featuers.Product.Query.GetProduct;
using Microsoft.Extensions.DependencyInjection;

namespace Croppilot.Core
{
    public static class ModelCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection service)
        {
            service.AddMediatR(con => con.RegisterServicesFromAssembly(typeof(GetAllProductHandlers).Assembly));

            return service;
        }
    }
}
