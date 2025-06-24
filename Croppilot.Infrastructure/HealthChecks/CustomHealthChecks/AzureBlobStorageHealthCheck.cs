using Azure.Storage.Blobs;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using Azure;

namespace Croppilot.Infrastructure.HealthChecks.CustomHealthChecks;

public class AzureBlobStorageHealthCheck(
    BlobServiceClient blobServiceClient,
    ILogger<AzureBlobStorageHealthCheck> logger)
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

            // 1. Check service properties connectivity
            var connectivityResult = await CheckServiceConnectivity(cancellationToken);
            results.Add($"Service Connectivity: {connectivityResult.status}");
            data["service_connectivity"] = connectivityResult.status;
            data["response_time_ms"] = connectivityResult.responseTime;

            // 2. Check if we can list containers
            var containerListResult = await CheckContainerListing(cancellationToken);
            results.Add($"Container Listing: {containerListResult.status}");
            data["container_listing"] = containerListResult.status == "Healthy";
            data["container_count"] = containerListResult.containerCount;

            // 3. Test blob operations on a test container
            var blobOperationsResult = await CheckBlobOperations(cancellationToken);
            results.Add($"Blob Operations: {blobOperationsResult.status}");
            data["blob_operations"] = blobOperationsResult.status == "Healthy";

            data["checks_performed"] = results;

            // Cast to IReadOnlyDictionary for HealthCheckResult
            var readOnlyData = (IReadOnlyDictionary<string, object>)data;

            // Determine overall health
            if (connectivityResult.status == "Healthy" && 
                containerListResult.status == "Healthy" && 
                blobOperationsResult.status == "Healthy")
            {
                return HealthCheckResult.Healthy("Azure Blob Storage is fully operational", readOnlyData);
            }

            if (connectivityResult.status == "Healthy")
            {
                return HealthCheckResult.Degraded("Azure Blob Storage is partially operational", null, readOnlyData);
            }

            return HealthCheckResult.Unhealthy("Azure Blob Storage is not accessible", null, readOnlyData);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during Azure Blob Storage health check");
            return HealthCheckResult.Unhealthy("Azure Blob Storage health check failed", ex);
        }
    }

    private async Task<(string status, long responseTime)> CheckServiceConnectivity(CancellationToken cancellationToken)
    {
        try
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Try to get service properties to test connectivity
            var response = await blobServiceClient.GetPropertiesAsync(cancellationToken);
            stopwatch.Stop();

            if (response?.Value != null)
            {
                logger.LogDebug("Azure Blob Storage connectivity check successful. Response time: {ResponseTime}ms",
                    stopwatch.ElapsedMilliseconds);
                return ("Healthy", stopwatch.ElapsedMilliseconds);
            }

            logger.LogWarning("Azure Blob Storage connectivity check failed - no response");
            return ("Unhealthy", stopwatch.ElapsedMilliseconds);
        }
        catch (RequestFailedException ex)
        {
            logger.LogError(ex, "Azure Blob Storage connectivity check failed with RequestFailedException: {StatusCode}", ex.Status);
            return ("Unhealthy", 0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Azure Blob Storage connectivity check failed with exception");
            return ("Unhealthy", 0);
        }
    }

    private async Task<(string status, int containerCount)> CheckContainerListing(CancellationToken cancellationToken)
    {
        try
        {
            var containers = blobServiceClient.GetBlobContainersAsync(cancellationToken: cancellationToken);
            var containerCount = 0;

            await foreach (var container in containers)
            {
                containerCount++;
                // Just count, don't enumerate all
                if (containerCount > 100) break; // Prevent excessive enumeration
            }

            logger.LogDebug("Successfully listed {ContainerCount} containers", containerCount);
            return ("Healthy", containerCount);
        }
        catch (RequestFailedException ex)
        {
            logger.LogError(ex, "Failed to list containers: {StatusCode}", ex.Status);
            return ("Unhealthy", 0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to list containers with exception");
            return ("Unhealthy", 0);
        }
    }

    private async Task<(string status, string? message)> CheckBlobOperations(CancellationToken cancellationToken)
    {
        const string testContainerName = "health-check-test";
        const string testBlobName = "health-check-blob.txt";
        
        try
        {
            // Get or create test container
            var containerClient = blobServiceClient.GetBlobContainerClient(testContainerName);
            
            // Check if container exists, create if it doesn't
            var containerExists = await containerClient.ExistsAsync(cancellationToken);
            if (!containerExists.Value)
            {
                await containerClient.CreateAsync(cancellationToken: cancellationToken);
                logger.LogDebug("Created test container for health check");
            }

            // Test blob upload
            var testContent = $"Health check test - {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC";
            var blobClient = containerClient.GetBlobClient(testBlobName);
            
            using var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(testContent));
            await blobClient.UploadAsync(stream, overwrite: true, cancellationToken: cancellationToken);

            // Test blob download
            var downloadResponse = await blobClient.DownloadContentAsync(cancellationToken);
            var downloadedContent = downloadResponse.Value.Content.ToString();

            // Test blob deletion
            await blobClient.DeleteIfExistsAsync(cancellationToken: cancellationToken);

            // Verify the content matches
            if (downloadedContent == testContent)
            {
                logger.LogDebug("Blob operations test successful");
                return ("Healthy", "Upload/Download/Delete operations successful");
            }

            logger.LogWarning("Blob operations test failed - content mismatch");
            return ("Unhealthy", "Content mismatch in blob operations");
        }
        catch (RequestFailedException ex)
        {
            logger.LogError(ex, "Blob operations test failed with RequestFailedException: {StatusCode}", ex.Status);
            return ("Unhealthy", $"RequestFailedException: {ex.Status}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Blob operations test failed with exception");
            return ("Unhealthy", ex.Message);
        }
    }
} 