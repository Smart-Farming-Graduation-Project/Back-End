using Azure;
using Azure.AI.OpenAI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using OpenAI.Chat;

namespace Croppilot.Infrastructure.HealthChecks.CustomHealthChecks;

public class OpenAIHealthCheck(
    IConfiguration configuration,
    ILogger<OpenAIHealthCheck> logger)
    : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var data = new Dictionary<string, object>();
            var results = new List<string>();

            // 1. Check configuration
            var configResult = CheckConfiguration();
            results.Add($"Configuration: {configResult.status}");
            data["configuration"] = configResult.status;
            
            if (configResult.status != "Healthy")
            {
                data["checks_performed"] = results;
                var readOnlyData = (IReadOnlyDictionary<string, object>)data;
                return HealthCheckResult.Unhealthy("OpenAI configuration is invalid", null, readOnlyData);
            }

            // 2. Check API connectivity
            var connectivityResult = await CheckApiConnectivity();
            results.Add($"API Connectivity: {connectivityResult.status}");
            data["api_connectivity"] = connectivityResult.status;
            data["response_time_ms"] = connectivityResult.responseTime;

            // 3. Test basic chat completion functionality
            var chatResult = await CheckChatCompletion(cancellationToken);
            results.Add($"Chat Completion: {chatResult.status}");
            data["chat_completion"] = chatResult.status == "Healthy";
            data["model_deployment"] = configuration["OpenAI:DeploymentName"];

            data["checks_performed"] = results;

            // Cast to IReadOnlyDictionary for HealthCheckResult
            var readOnlyDataFinal = (IReadOnlyDictionary<string, object>)data;

            // Determine overall health
            if (connectivityResult.status == "Healthy" && chatResult.status == "Healthy")
            {
                return HealthCheckResult.Healthy("OpenAI service is fully operational", readOnlyDataFinal);
            }

            if (connectivityResult.status == "Healthy")
            {
                return HealthCheckResult.Degraded("OpenAI API is accessible but chat completion failed", null, readOnlyDataFinal);
            }

            return HealthCheckResult.Unhealthy("OpenAI service is not accessible", null, readOnlyDataFinal);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during OpenAI health check");
            return HealthCheckResult.Unhealthy("OpenAI health check failed", ex);
        }
    }

    private (string status, string? message) CheckConfiguration()
    {
        try
        {
            var endpoint = configuration["OpenAI:Endpoint"];
            var key = configuration["OpenAI:Key"];
            var deploymentName = configuration["OpenAI:DeploymentName"];

            if (string.IsNullOrEmpty(endpoint))
            {
                logger.LogWarning("OpenAI endpoint is not configured");
                return ("Unhealthy", "OpenAI endpoint is missing");
            }

            if (string.IsNullOrEmpty(key))
            {
                logger.LogWarning("OpenAI API key is not configured");
                return ("Unhealthy", "OpenAI API key is missing");
            }

            if (string.IsNullOrEmpty(deploymentName))
            {
                logger.LogWarning("OpenAI deployment name is not configured");
                return ("Unhealthy", "OpenAI deployment name is missing");
            }

            // Validate endpoint format
            if (!Uri.TryCreate(endpoint, UriKind.Absolute, out _))
            {
                logger.LogWarning("OpenAI endpoint is not a valid URL: {Endpoint}", endpoint);
                return ("Unhealthy", "OpenAI endpoint is not a valid URL");
            }

            logger.LogDebug("OpenAI configuration validation successful");
            return ("Healthy", "Configuration is valid");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error validating OpenAI configuration");
            return ("Unhealthy", ex.Message);
        }
    }

    private async Task<(string status, long responseTime)> CheckApiConnectivity()
    {
        try
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var endpoint = configuration["OpenAI:Endpoint"];
            var key = configuration["OpenAI:Key"];

            var credential = new AzureKeyCredential(key!);
            var azureClient = new AzureOpenAIClient(new Uri(endpoint!), credential);

            // Test connectivity by attempting to get deployment information
            // This is a lightweight operation that verifies the connection
            var deploymentName = configuration["OpenAI:DeploymentName"];
            var chatClient = azureClient.GetChatClient(deploymentName!);

            stopwatch.Stop();

            if (chatClient != null)
            {
                logger.LogDebug("OpenAI API connectivity check successful. Response time: {ResponseTime}ms",
                    stopwatch.ElapsedMilliseconds);
                return ("Healthy", stopwatch.ElapsedMilliseconds);
            }

            logger.LogWarning("OpenAI API connectivity check failed - unable to create chat client");
            return ("Unhealthy", stopwatch.ElapsedMilliseconds);
        }
        catch (RequestFailedException ex)
        {
            logger.LogError(ex, "OpenAI API connectivity check failed with RequestFailedException: {StatusCode}", ex.Status);
            return ("Unhealthy", 0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "OpenAI API connectivity check failed with exception");
            return ("Unhealthy", 0);
        }
    }

    private async Task<(string status, string? message)> CheckChatCompletion(CancellationToken cancellationToken)
    {
        try
        {
            var endpoint = configuration["OpenAI:Endpoint"];
            var key = configuration["OpenAI:Key"];
            var deploymentName = configuration["OpenAI:DeploymentName"];

            var credential = new AzureKeyCredential(key!);
            var azureClient = new AzureOpenAIClient(new Uri(endpoint!), credential);
            var chatClient = azureClient.GetChatClient(deploymentName!);

            // Test with a simple health check message
            var messages = new List<ChatMessage>
            {
                new SystemChatMessage("You are a health check assistant. Respond with exactly 'OK' to confirm you are working."),
                new UserChatMessage("Health check test")
            };

            using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            cts.CancelAfter(TimeSpan.FromSeconds(30)); // 30-second timeout for health check

            var response = await chatClient.CompleteChatAsync(messages, cancellationToken: cts.Token);

            if (response?.Value?.Content?.Count > 0)
            {
                var content = response.Value.Content[0].Text;
                logger.LogDebug("OpenAI chat completion test successful. Response: {Response}", content);
                return ("Healthy", "Chat completion successful");
            }

            logger.LogWarning("OpenAI chat completion test failed - empty response");
            return ("Unhealthy", "Empty response from chat completion");
        }
        catch (TaskCanceledException)
        {
            logger.LogWarning("OpenAI chat completion test timed out");
            return ("Unhealthy", "Chat completion request timed out");
        }
        catch (RequestFailedException ex)
        {
            logger.LogError(ex, "OpenAI chat completion test failed with RequestFailedException: {StatusCode}", ex.Status);
            return ("Unhealthy", $"RequestFailedException: {ex.Status}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "OpenAI chat completion test failed with exception");
            return ("Unhealthy", ex.Message);
        }
    }
} 