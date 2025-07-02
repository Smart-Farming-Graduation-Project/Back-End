using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Croppilot.Core.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class CacheInvalidateAttribute : Attribute, IAsyncActionFilter
{
    private readonly string[] _entityNames;
    private readonly bool _invalidateUserCache;

    public CacheInvalidateAttribute(params string[] entityNames)
    {
        _entityNames = entityNames ?? throw new ArgumentNullException(nameof(entityNames));
        _invalidateUserCache = false;
    }

    public CacheInvalidateAttribute(bool invalidateUserCache, params string[] entityNames)
    {
        _entityNames = entityNames ?? Array.Empty<string>();
        _invalidateUserCache = invalidateUserCache;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var executedContext = await next();

        // Only invalidate cache if the action was successful
        if (executedContext.Exception == null && IsSuccessfulResult(executedContext))
        {
            var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var cacheKeyGenerator = context.HttpContext.RequestServices.GetRequiredService<ICacheKeyGenerator>();

            // Invalidate entity-specific caches
            foreach (var entityName in _entityNames)
            {
                var pattern = cacheKeyGenerator.GeneratePattern(entityName);
                await cacheService.RemoveByPatternAsync(pattern);
            }

            // Invalidate user-specific cache if requested
            if (_invalidateUserCache && context.HttpContext.User.Identity?.IsAuthenticated == true)
            {
                var userId = GetUserId(context);
                if (!string.IsNullOrEmpty(userId))
                {
                    var userPattern = cacheKeyGenerator.GeneratePattern($"user:{userId}");
                    await cacheService.RemoveByPatternAsync(userPattern);
                }
            }
        }
    }

    private static bool IsSuccessfulResult(ActionExecutedContext context)
    {
        if (context.Result is Microsoft.AspNetCore.Mvc.ObjectResult objectResult)
        {
            return objectResult.StatusCode is >= 200 and < 300;
        }

        return context.Result is not Microsoft.AspNetCore.Mvc.BadRequestObjectResult &&
               context.Result is not Microsoft.AspNetCore.Mvc.NotFoundObjectResult;
    }

    private static string? GetUserId(ActionExecutingContext context)
    {
        return context.HttpContext.User.FindFirst("sub")?.Value ??
               context.HttpContext.User.FindFirst("id")?.Value ??
               context.HttpContext.User.Identity?.Name;
    }
} 