using Azure.Storage.Blobs;
using Croppilot.Date.Helpers;
using Croppilot.Services.Abstract.AiSerives;
using Croppilot.Services.Abstract.DashboredServices;
using Croppilot.Services.Abstract.EmbbeddedServices;
using Croppilot.Services.Services;
using Croppilot.Services.Services.AIServises;
using Croppilot.Services.Services.DashboredServices;
using Croppilot.Services.Services.EmbbeddedSerivces;
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
                _ => new BlobServiceClient(configuration.GetSection("AzureKey:ConnectionString").Value));

            service.Configure<StripeSettings>(configuration.GetSection("Stripe"));


            service.AddScoped<IProductServices, ProductServices>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ILeasingService, LeasingService>();
            service.AddScoped<IProductImageServices, ProductImageServices>();
            service.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IEmailService, EmailService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAuthorizationService, AuthorizationService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<ICartService, CartService>();
            service.AddScoped<IExternalAuthService, ExternalAuthService>();
            service.AddScoped<IWishlistService, WishlistService>();
            service.AddScoped<IReviewService, ReviewService>();
            service.AddScoped<IChatService, ChatService>();
            service.AddScoped<IPostService, PostService>();
            service.AddScoped<ICommentService, CommentService>();
            service.AddScoped<IVoteService, VoteService>();

            service.AddScoped<INotificationServices, NotificationServices>();

            service.AddScoped<IPaymentService, PaymentService>();
            service.AddScoped<ICuponService, CuponService>();
            service.AddScoped<INotificationServices, NotificationServices>();



            service.AddScoped<ICosmosDbService, CosmosDbService>();
            service.AddScoped<IModelServices, ModelServices>();
            service.AddScoped<IRlPredictServices, RlPredictServices>();


            service.AddScoped<IWeatherServices, WeatherServices>();
            service.AddScoped<IFieldService, FieldService>();
            service.AddScoped<IEquipmentService, EquipmentService>();
            service.AddScoped<IFarmStatusService, FarmStatusService>();
            service.AddScoped<ISoilServices, SoilServices>();
            service.AddScoped<IAlertsServices, AlertsServices>();
            service.AddHttpClient();



            return service;
        }
    }
}

