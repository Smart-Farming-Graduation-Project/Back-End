using Croppilot.Infrastructure.HealthChecks.CustomHealthChecks;
using Croppilot.Infrastructure.HealthChecks.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Croppilot.Infrastructure.HealthChecks.Extensions;

public static class HealthCheckExtensions
{
    public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure options for MailJet
        services.Configure<MailJetHealthCheckOptions>(options =>
        {
            options.ApiKey = configuration["MailJet:ApiKey"] ?? string.Empty;
            options.SecretKey = configuration["MailJet:SecretKey"] ?? string.Empty;
            options.TestEmailFrom = configuration["Email:From"] ?? string.Empty;
            options.TestEmailTo = configuration["HealthCheck:TestEmail"] ?? string.Empty;
            options.EnableTestEmail = configuration.GetValue<bool>("HealthCheck:EnableTestEmail", false);
            options.TimeoutSeconds = configuration.GetValue<int>("HealthCheck:TimeoutSeconds", 30);
        });

        // Configure options for Stripe
        services.Configure<StripeHealthCheckOptions>(options =>
        {
            options.SecretKey = configuration["Stripe:Secretkey"] ?? string.Empty;
            options.PublishableKey = configuration["Stripe:PublishableKey"] ?? string.Empty;
            options.WebhookSecret = configuration["Stripe:WebhookSecret"] ?? string.Empty;
            options.EnableListProducts = configuration.GetValue<bool>("HealthCheck:Stripe:EnableListProducts", true);
            options.EnableCreateTestPrice = configuration.GetValue<bool>("HealthCheck:Stripe:EnableCreateTestPrice", false);
            options.TimeoutSeconds = configuration.GetValue<int>("HealthCheck:TimeoutSeconds", 30);
            options.MaxRetrieveCount = configuration.GetValue<int>("HealthCheck:Stripe:MaxRetrieveCount", 5);
        });

        // Register HTTP clients for health checks
        services.AddHttpClient<MailJetHealthCheck>(client =>
        {
            client.Timeout = TimeSpan.FromSeconds(30);
        });
        

        // Register health checks
        services.AddHealthChecks()
            .AddCheck<MailJetHealthCheck>(
                name: "MailJet API",
                failureStatus: HealthStatus.Unhealthy,
                tags: ["email", "mailjet", "external", "api"])
            .AddCheck<AzureBlobStorageHealthCheck>(
                name: "Azure Blob Storage",
                failureStatus: HealthStatus.Unhealthy,
                tags: ["storage", "azure", "blob", "external"])
            .AddCheck<OpenAIHealthCheck>(
                name: "OpenAI API",
                failureStatus: HealthStatus.Unhealthy,
                tags: ["ai", "openai", "external", "api"])
            .AddCheck<StripeHealthCheck>(
                name: "Stripe Payment API",
                failureStatus: HealthStatus.Unhealthy,
                tags: ["payment", "stripe", "external", "api"])
            .AddRedis(
                configuration.GetSection("Redis:ConnectionString").Value ?? string.Empty,
                name: "Redis Cache",
                failureStatus: HealthStatus.Unhealthy,
                tags: ["cache", "redis", "external", "database"]);

        return services;
    }
}