using Microsoft.Extensions.Logging;

namespace Croppilot.Services.Services;

public class UserFavoritesService(
    ICacheService cacheService,
    ICacheKeyGenerator cacheKeyGenerator,
    IWishlistService wishlistService,
    ILogger<UserFavoritesService> logger)
    : IUserFavoritesService
{
    private const int CACHE_EXPIRATION_MINUTES = 30;

    public async Task<Dictionary<int, bool>> GetUserFavoritesAsync(string userId, List<int> productIds, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(userId) || !productIds.Any())
        {
            return productIds.ToDictionary(id => id, _ => false);
        }

        try
        {
            var favoriteProductIds = await GetUserFavoriteProductIdsAsync(userId, cancellationToken);
            
            // Convert the set of favorited IDs to the requested dictionary format
            return productIds.ToDictionary(
                id => id, 
                id => favoriteProductIds.Contains(id)
            );
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting user favorites for user {UserId}", userId);
            return productIds.ToDictionary(id => id, _ => false);
        }
    }

    public async Task<bool> GetUserFavoriteAsync(string userId, int productId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(userId))
            return false;

        try
        {
            var favoriteProductIds = await GetUserFavoriteProductIdsAsync(userId, cancellationToken);
            return favoriteProductIds.Contains(productId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting user favorite for user {UserId}, product {ProductId}", userId, productId);
            return false;
        }
    }

    public async Task RefreshUserFavoritesAsync(string userId, List<int> productIds, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(userId))
            return;

        try
        {
            await RefreshUserFavoriteProductIdsAsync(userId, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error refreshing user favorites for user {UserId}", userId);
        }
    }

    public async Task InvalidateUserFavoritesAsync(string userId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(userId))
            return;

        try
        {
            var cacheKey = cacheKeyGenerator.GenerateUserKey(userId, "favorites");
            await cacheService.RemoveAsync(cacheKey, cancellationToken);
            logger.LogDebug("Invalidated user favorites cache for user {UserId}", userId);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error invalidating user favorites for user {UserId}", userId);
        }
    }

    /// <summary>
    /// Gets the set of product IDs that the user has favorited (from cache or database)
    /// </summary>
    private async Task<HashSet<int>> GetUserFavoriteProductIdsAsync(string userId, CancellationToken cancellationToken)
    {
        var cacheKey = cacheKeyGenerator.GenerateUserKey(userId, "favorites");
        var cachedFavorites = await cacheService.GetAsync<UserProductFavorites>(cacheKey, cancellationToken);

        if (cachedFavorites != null && IsValidCache(cachedFavorites))
        {
            logger.LogDebug("Cache hit for user favorites: {UserId}, {Count} favorites", 
                userId, cachedFavorites.FavoriteProductIds.Count);
            return cachedFavorites.FavoriteProductIds;
        }

        // Cache miss or expired - refresh from database
        return await RefreshUserFavoriteProductIdsAsync(userId, cancellationToken);
    }

    /// <summary>
    /// Refreshes the user's favorite product IDs from the database and caches them
    /// </summary>
    private async Task<HashSet<int>> RefreshUserFavoriteProductIdsAsync(string userId, CancellationToken cancellationToken)
    {
        // Get user's wishlist from database
        var wishlist = await wishlistService.GetWishlistByUserIdAsync(userId);
        
        // Extract only the product IDs that are favorited
        var favoriteProductIds = wishlist?.WishlistItems?.Select(wi => wi.ProductId).ToHashSet() ?? new HashSet<int>();

        // Cache the favorites (only the IDs, not all products)
        var userFavorites = new UserProductFavorites(
            userId,
            favoriteProductIds,
            DateTime.UtcNow
        );

        var cacheKey = cacheKeyGenerator.GenerateUserKey(userId, "favorites");
        var expiration = TimeSpan.FromMinutes(CACHE_EXPIRATION_MINUTES);
        await cacheService.SetAsync(cacheKey, userFavorites, expiration, cancellationToken);

        logger.LogDebug("Refreshed user favorites cache for user {UserId} with {Count} favorited products", 
            userId, favoriteProductIds.Count);

        return favoriteProductIds;
    }

    private static bool IsValidCache(UserProductFavorites cachedFavorites)
    {
        // Cache is valid for 30 minutes
        return DateTime.UtcNow - cachedFavorites.LastUpdated < TimeSpan.FromMinutes(CACHE_EXPIRATION_MINUTES);
    }
} 