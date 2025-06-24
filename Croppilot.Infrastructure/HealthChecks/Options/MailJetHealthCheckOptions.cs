namespace Croppilot.Infrastructure.HealthChecks.Options;

public class MailJetHealthCheckOptions
{
    public string ApiKey { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
    public string TestEmailFrom { get; set; } = string.Empty;
    public string TestEmailTo { get; set; } = string.Empty;
    public bool EnableTestEmail { get; set; } = false;
    public int TimeoutSeconds { get; set; } = 30;
}