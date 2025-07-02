using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Croppilot.Core.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CacheAttribute(int timeToLiveSeconds = 3600, bool varyByUser = false) : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
        var cacheKeyGenerator = context.HttpContext.RequestServices.GetRequiredService<ICacheKeyGenerator>();

        var cacheKey = GenerateCacheKeyFromContext(context, cacheKeyGenerator);

        var cachedResponse = await cacheService.GetAsync<object>(cacheKey);
        if (cachedResponse is not null)
        {
            context.Result = new OkObjectResult(cachedResponse);
            return;
        }

        var executedContext = await next();

        if (executedContext.Result is OkObjectResult okResult && okResult.Value is not null)
        {
            var expiration = TimeSpan.FromSeconds(timeToLiveSeconds);
            await cacheService.SetAsync(cacheKey, okResult.Value, expiration);
        }
    }

    private string GenerateCacheKeyFromContext(ActionExecutingContext context, ICacheKeyGenerator keyGenerator)
    {
        var controllerName = context.RouteData.Values["controller"]?.ToString() ?? "unknown";
        var actionName = context.RouteData.Values["action"]?.ToString() ?? "unknown";

        // Collect all parameters for key generation
        var parameters = new List<object>
        {
            // Add action name
            $"action:{actionName}"
        };

        // Add route parameters
        foreach (var routeValue in context.RouteData.Values.Where(rv => rv.Key != "controller" && rv.Key != "action"))
        {
            parameters.Add($"{routeValue.Key}={routeValue.Value}");
        }

        // Add query parameters
        foreach (var queryParam in context.HttpContext.Request.Query.OrderBy(q => q.Key))
        {
            parameters.Add($"q_{queryParam.Key}={queryParam.Value}");
        }

        // Use appropriate ICacheKeyGenerator method based on context
        if (varyByUser && context.HttpContext.User.Identity?.IsAuthenticated == true)
        {
            var userId = GetUserId(context);
            if (!string.IsNullOrEmpty(userId))
            {
                return keyGenerator.GenerateUserKey(userId, controllerName, parameters.ToArray());
            }
        }

        // For non-user specific caching, use collection key
        return keyGenerator.GenerateCollectionKey(controllerName, parameters.ToArray());
    }

    private static string? GetUserId(ActionExecutingContext context)
    {
        return context.HttpContext.User.FindFirst("sub")?.Value ??
               context.HttpContext.User.FindFirst("id")?.Value ??
               context.HttpContext.User.Identity?.Name;
    }
}