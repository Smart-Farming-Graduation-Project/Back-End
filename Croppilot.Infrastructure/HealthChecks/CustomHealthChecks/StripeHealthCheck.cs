using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Stripe;
using Croppilot.Infrastructure.HealthChecks.Options;

namespace Croppilot.Infrastructure.HealthChecks.CustomHealthChecks;

public class StripeHealthCheck(
    IOptions<StripeHealthCheckOptions> options,
    ILogger<StripeHealthCheck> logger)
    : IHealthCheck
{
    private readonly StripeHealthCheckOptions _options = options.Value;

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Configure Stripe API key
            StripeConfiguration.ApiKey = _options.SecretKey;

            var results = new List<string>();
            var data = new Dictionary<string, object>();

            // 1. Check API connectivity by retrieving account info
            var connectivityResult = await CheckApiConnectivity(cancellationToken);
            results.Add($"API Connectivity: {connectivityResult.status}");
            data["api_connectivity"] = connectivityResult.status;
            data["response_time_ms"] = connectivityResult.responseTime;
            data["account_info"] = connectivityResult.accountInfo ?? new { };

            // 2. Test listing products (if enabled)
            bool productListSuccess = true;
            if (_options.EnableListProducts)
            {
                var productResult = await CheckProductListing(cancellationToken);
                results.Add($"Product Listing: {productResult.status}");
                data["product_listing"] = productResult.status == "Healthy";
                data["product_count"] = productResult.productCount;
                productListSuccess = productResult.status == "Healthy";
            }

            // 3. Test creating a test price (if enabled)
            bool testPriceSuccess = true;
            if (_options.EnableCreateTestPrice)
            {
                var priceResult = await CheckTestPriceCreation(cancellationToken);
                results.Add($"Test Price Creation: {priceResult.status}");
                data["test_price_creation"] = priceResult.status == "Healthy";
                testPriceSuccess = priceResult.status == "Healthy";
            }

            // 4. Check webhook endpoint secret is configured
            var webhookResult = CheckWebhookConfiguration();
            results.Add($"Webhook Configuration: {webhookResult.status}");
            data["webhook_configured"] = webhookResult.status == "Healthy";

            data["checks_performed"] = results;

            // Cast to IReadOnlyDictionary for HealthCheckResult
            var readOnlyData = (IReadOnlyDictionary<string, object>)data;

            // Determine overall health
            if (connectivityResult.status == "Healthy" &&
                (!_options.EnableListProducts || productListSuccess) &&
                (!_options.EnableCreateTestPrice || testPriceSuccess) &&
                webhookResult.status == "Healthy")
            {
                return HealthCheckResult.Healthy("Stripe service is fully operational", readOnlyData);
            }

            if (connectivityResult.status == "Healthy")
            {
                return HealthCheckResult.Degraded("Stripe API is accessible but some operations failed", null,
                    readOnlyData);
            }

            return HealthCheckResult.Unhealthy("Stripe service is not accessible", null, readOnlyData);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during Stripe health check");
            return HealthCheckResult.Unhealthy("Stripe health check failed", ex);
        }
    }

    private async Task<(string status, long responseTime, object? accountInfo)> CheckApiConnectivity(
        CancellationToken cancellationToken)
    {
        try
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var service = new AccountService();

            // Correct usage: pass "self" as the account ID
            var account = await service.GetAsync("self", cancellationToken: cancellationToken);
            stopwatch.Stop();

            if (account != null)
            {
                logger.LogDebug(
                    "Stripe API connectivity check successful. Response time: {ResponseTime}ms, Account ID: {AccountId}",
                    stopwatch.ElapsedMilliseconds, account.Id);

                var accountInfo = new
                {
                    id = account.Id,
                    country = account.Country,
                    default_currency = account.DefaultCurrency,
                    charges_enabled = account.ChargesEnabled,
                    payouts_enabled = account.PayoutsEnabled
                };

                return ("Healthy", stopwatch.ElapsedMilliseconds, accountInfo);
            }

            logger.LogWarning("Stripe API connectivity check failed - no account response");
            return ("Unhealthy", stopwatch.ElapsedMilliseconds, null);
        }
        catch (StripeException ex)
        {
            logger.LogError(ex,
                "Stripe API connectivity check failed with StripeException: {ErrorType} - {ErrorMessage}",
                ex.StripeError?.Type, ex.StripeError?.Message);
            return ("Unhealthy", 0, null);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Stripe API connectivity check failed with exception");
            return ("Unhealthy", 0, null);
        }
    }

    private async Task<(string status, int productCount)> CheckProductListing(CancellationToken cancellationToken)
    {
        try
        {
            var service = new ProductService();
            var options = new ProductListOptions
            {
                Limit = _options.MaxRetrieveCount
            };

            var products = await service.ListAsync(options, cancellationToken: cancellationToken);

            if (products?.Data != null)
            {
                logger.LogDebug("Successfully listed {ProductCount} products from Stripe", products.Data.Count());
                return ("Healthy", products.Data.Count());
            }

            logger.LogWarning("Failed to list products from Stripe - no data returned");
            return ("Unhealthy", 0);
        }
        catch (StripeException ex)
        {
            logger.LogError(ex, "Failed to list products from Stripe: {ErrorType} - {ErrorMessage}",
                ex.StripeError?.Type, ex.StripeError?.Message);
            return ("Unhealthy", 0);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to list products from Stripe with exception");
            return ("Unhealthy", 0);
        }
    }

    private async Task<(string status, string? priceId)> CheckTestPriceCreation(CancellationToken cancellationToken)
    {
        try
        {
            var priceService = new PriceService();
            var productService = new ProductService();

            // First create a test product
            var productOptions = new ProductCreateOptions
            {
                Name = $"Health Check Test Product - {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}",
                Description = "Temporary product for health check - will be deleted",
                Metadata = new Dictionary<string, string>
                {
                    { "health_check", "true" },
                    { "created_at", DateTime.UtcNow.ToString("O") }
                }
            };

            var product = await productService.CreateAsync(productOptions, cancellationToken: cancellationToken);

            // Create a test price for the product
            var priceOptions = new PriceCreateOptions
            {
                UnitAmount = 100, // $1.00
                Currency = "usd",
                Product = product.Id,
                Metadata = new Dictionary<string, string>
                {
                    { "health_check", "true" },
                    { "created_at", DateTime.UtcNow.ToString("O") }
                }
            };

            var price = await priceService.CreateAsync(priceOptions, cancellationToken: cancellationToken);

            // Clean up - delete the test product (this will also delete the price)
            await productService.DeleteAsync(product.Id, cancellationToken: cancellationToken);

            if (price != null)
            {
                logger.LogInformation("Successfully created and deleted test price in Stripe. Price ID: {PriceId}",
                    price.Id);
                return ("Healthy", price.Id);
            }

            logger.LogWarning("Failed to create test price in Stripe - no price returned");
            return ("Unhealthy", null);
        }
        catch (StripeException ex)
        {
            logger.LogError(ex, "Failed to create test price in Stripe: {ErrorType} - {ErrorMessage}",
                ex.StripeError?.Type, ex.StripeError?.Message);
            return ("Unhealthy", null);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to create test price in Stripe with exception");
            return ("Unhealthy", null);
        }
    }

    private (string status, string message) CheckWebhookConfiguration()
    {
        try
        {
            if (string.IsNullOrEmpty(_options.WebhookSecret))
            {
                logger.LogWarning("Stripe webhook secret is not configured");
                return ("Unhealthy", "Webhook secret not configured");
            }

            if (!_options.WebhookSecret.StartsWith("whsec_"))
            {
                logger.LogWarning("Stripe webhook secret format appears invalid");
                return ("Degraded", "Webhook secret format may be invalid");
            }

            logger.LogDebug("Stripe webhook secret is properly configured");
            return ("Healthy", "Webhook secret properly configured");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error checking webhook configuration");
            return ("Unhealthy", ex.Message);
        }
    }
}