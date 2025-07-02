namespace Croppilot.Services.Abstract;

/// <summary>
/// Service for managing user-specific product favorites cache
/// </summary>
public interface IUserFavoritesService
{
    /// <summary>
    /// Gets the favorite status for multiple products for a specific user
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="productIds">List of product IDs to check</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Dictionary with ProductId -> IsFavorite mapping</returns>
    Task<Dictionary<int, bool>> GetUserFavoritesAsync(string userId, List<int> productIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the favorite status for a single product for a specific user
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="productId">Product ID to check</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the product is a favorite, false otherwise</returns>
    Task<bool> GetUserFavoriteAsync(string userId, int productId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the user's favorites cache
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="productIds">List of product IDs to cache favorites for</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task RefreshUserFavoritesAsync(string userId, List<int> productIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Invalidates the user's favorites cache when wishlist changes
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="cancellationToken">Cancellation token</param>
    Task InvalidateUserFavoritesAsync(string userId, CancellationToken cancellationToken = default);
} 