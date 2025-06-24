using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;
using Croppilot.Infrastructure.HealthChecks.Options;
using Microsoft.Extensions.Logging;

namespace Croppilot.Infrastructure.HealthChecks.CustomHealthChecks;

public class MailJetHealthCheck(
    HttpClient httpClient,
    IOptions<MailJetHealthCheckOptions> options,
    ILogger<MailJetHealthCheck> logger)
    : IHealthCheck
{
    private readonly MailJetHealthCheckOptions _options = options.Value;

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Configure timeout
            httpClient.Timeout = TimeSpan.FromSeconds(_options.TimeoutSeconds);

            var results = new List<string>();
            var data = new Dictionary<string, object>();

            // 1. Check API connectivity
            var connectivityResult = await CheckApiConnectivity(cancellationToken);
            results.Add($"API Connectivity: {connectivityResult.status}");
            data["api_connectivity"] = connectivityResult.status;
            data["response_time_ms"] = connectivityResult.responseTime;

            // 2. Optional: Send test email (only if enabled)
            bool testEmailSuccess = true;
            if (_options.EnableTestEmail && !string.IsNullOrEmpty(_options.TestEmailTo))
            {
                var emailResult = await SendTestEmail(cancellationToken);
                results.Add($"Test Email: {emailResult.status}");
                data["test_email_sent"] = emailResult.status == "Healthy";
                testEmailSuccess = emailResult.status == "Healthy";
            }

            data["checks_performed"] = results;

            // Cast to IReadOnlyDictionary for HealthCheckResult
            var readOnlyData = (IReadOnlyDictionary<string, object>)data;

            // Determine overall health
            if (connectivityResult.status == "Healthy")
            {
                if (!_options.EnableTestEmail || testEmailSuccess)
                {
                    return HealthCheckResult.Healthy("MailJet service is fully operational", readOnlyData);
                }

                return HealthCheckResult.Degraded("MailJet API is accessible but test email failed", null,
                    readOnlyData);
            }

            return HealthCheckResult.Unhealthy("MailJet service is not accessible", null, readOnlyData);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during MailJet health check");
            return HealthCheckResult.Unhealthy("MailJet health check failed", ex);
        }
    }

    private async Task<(string status, long responseTime)> CheckApiConnectivity(CancellationToken cancellationToken)
    {
        try
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            using var request = new HttpRequestMessage(HttpMethod.Get, "https://api.mailjet.com/v3/REST/sender");
            var credentials = Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{_options.ApiKey}:{_options.SecretKey}"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);

            var response = await httpClient.SendAsync(request, cancellationToken);
            stopwatch.Stop();

            if (response.IsSuccessStatusCode)
            {
                logger.LogDebug("MailJet API connectivity check successful. Response time: {ResponseTime}ms",
                    stopwatch.ElapsedMilliseconds);
                return ("Healthy", stopwatch.ElapsedMilliseconds);
            }

            logger.LogWarning("MailJet API connectivity check failed with status code: {StatusCode}",
                response.StatusCode);
            return ("Unhealthy", stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "MailJet API connectivity check failed with exception");
            return ("Unhealthy", 0);
        }
    }

    private async Task<(string status, object? messageData)> SendTestEmail(CancellationToken cancellationToken)
    {
        try
        {
            var emailPayload = new
            {
                Messages = new[]
                {
                    new
                    {
                        From = new { Email = _options.TestEmailFrom, Name = "CropGuard Health Check" },
                        To = new[] { new { Email = _options.TestEmailTo } },
                        Subject = "CropGuard Health Check",
                        TextPart = $"Health check test email sent at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC",
                        HTMLPart =
                            $"<h3>Health check test email</h3><p>Sent at {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</p>"
                    }
                }
            };

            var json = JsonSerializer.Serialize(emailPayload);
            using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mailjet.com/v3.1/send");

            var credentials = Convert.ToBase64String(
                Encoding.ASCII.GetBytes($"{_options.ApiKey}:{_options.SecretKey}"));
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                logger.LogInformation("MailJet test email sent successfully");
                return ("Healthy", null);
            }

            logger.LogWarning("MailJet test email failed with status code: {StatusCode}", response.StatusCode);
            return ("Unhealthy", null);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to send test email");
            return ("Unhealthy", ex.Message);
        }
    }
}