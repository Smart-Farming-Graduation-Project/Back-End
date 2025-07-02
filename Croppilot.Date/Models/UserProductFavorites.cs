namespace Croppilot.Date.Models;

/// <summary>
/// Represents user-specific favorite product IDs (only stores favorited products)
/// </summary>
public record UserProductFavorites(
    string UserId,
    HashSet<int> FavoriteProductIds, // Only store IDs of products that are actually favorited
    DateTime LastUpdated
);

/// <summary>
/// Represents a single product's favorite status for a user
/// </summary>
public record ProductFavoriteStatus(
    int ProductId,
    bool IsFavorite
); 