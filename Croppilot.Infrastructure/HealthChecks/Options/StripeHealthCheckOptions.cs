namespace Croppilot.Infrastructure.HealthChecks.Options;

public class StripeHealthCheckOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public string PublishableKey { get; set; } = string.Empty;
    public string WebhookSecret { get; set; } = string.Empty;
    public bool EnableListProducts { get; set; } = true;
    public bool EnableCreateTestPrice { get; set; } = false;
    public int TimeoutSeconds { get; set; } = 30;
    public int MaxRetrieveCount { get; set; } = 5;
} 