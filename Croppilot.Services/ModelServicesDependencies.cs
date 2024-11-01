using Azure.Storage.Blobs;
using Croppilot.Services.Abstract;
using Croppilot.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Croppilot.Services
{
    public static class ModelServicesDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton(u => new BlobServiceClient(configuration.GetSection("AzureKey:ConnectionString").Value));

            service.AddScoped<IProductServices, ProductServices>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ILeasingService, LeasingService>();
            service.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();
            return service;
        }
    }
}