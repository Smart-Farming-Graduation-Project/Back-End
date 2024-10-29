using Microsoft.Extensions.DependencyInjection;
using Croppilot.Services.Abstract;
using Croppilot.Services.Services;

namespace Croppilot.Services
{
    public static class ModelServicesDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection service)
        {
            service.AddScoped<IProductServices, ProductServices>();
            service.AddScoped<ICategoryService, CategoryService>();

            return service;
        }
    }
}