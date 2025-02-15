using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Date.Models;

namespace Croppilot.Services.Services;

public class WishlistService(IWishlistRepository wishlistRepository) : IWishlistService
{
    public async Task<OperationResult> CreateWishlistAsync(Wishlist wishlist,
        CancellationToken cancellationToken = default)
    {
        await wishlistRepository.AddAsync(wishlist, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<Wishlist?> GetWishlistByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await wishlistRepository.GetAsync(
            filter: w => w.UserId == userId,
            includeProperties: ["WishlistItems.Product"],
            cancellationToken: cancellationToken,
            tracked: true);
    }

    public async Task<OperationResult> UpdateWishlistAsync(Wishlist wishlist,
        CancellationToken cancellationToken = default)
    {
        wishlist.UpdatedAt = DateTime.UtcNow;
        await wishlistRepository.UpdateAsync(wishlist, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<bool> DeleteWishlistAsync(int wishlistId, CancellationToken cancellationToken = default)
    {
        var wishlist = await wishlistRepository.GetAsync(w => w.Id == wishlistId, cancellationToken: cancellationToken);
        if (wishlist == null)
            return false;

        await wishlistRepository.DeleteAsync(wishlist, cancellationToken);
        return true;
    }
}