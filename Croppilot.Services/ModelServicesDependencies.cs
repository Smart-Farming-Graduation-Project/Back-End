using Azure.Storage.Blobs;
using Croppilot.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Croppilot.Services
{
    public static class ModelServicesDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddSingleton(
                u => new BlobServiceClient(configuration.GetSection("AzureKey:ConnectionString").Value));

            service.AddScoped<IProductServices, ProductServices>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ILeasingService, LeasingService>();
            service.AddScoped<IProductImageServices, ProductImageServices>();
            service.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IEmailService, EmailService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAuthorizationService, AuthorizationService>(); service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<ICartService, CartService>();
            service.AddScoped<IExternalAuthService, ExternalAuthService>();
            service.AddScoped<IWishlistService, WishlistService>();
            service.AddScoped<IReviewService, ReviewService>();
            service.AddScoped<IChatService, ChatService>();
            service.AddHttpClient();

            return service;
        }
    }
}