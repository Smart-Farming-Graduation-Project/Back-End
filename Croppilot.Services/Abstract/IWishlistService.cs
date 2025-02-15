namespace Croppilot.Services.Abstract;

public interface IWishlistService
{
    Task<OperationResult> CreateWishlistAsync(Wishlist wishlist, CancellationToken cancellationToken = default);
    Task<Wishlist?> GetWishlistByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<OperationResult> UpdateWishlistAsync(Wishlist wishlist, CancellationToken cancellationToken = default);
    Task<bool> DeleteWishlistAsync(int wishlistId, CancellationToken cancellationToken = default);
}