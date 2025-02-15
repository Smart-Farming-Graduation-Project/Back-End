using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services;

public class CartService(ICartRepository cartRepository) : ICartService
{
    public async Task<OperationResult> CreateCartAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        await cartRepository.AddAsync(cart, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<Cart?> GetCartByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await cartRepository.GetAsync(
            filter: c => c.UserId == userId,
            includeProperties: ["CartItems.Product"],
            cancellationToken: cancellationToken,
            tracked: true);
    }

    public async Task<OperationResult> UpdateCartAsync(Cart cart, CancellationToken cancellationToken = default)
    {
        cart.UpdatedAt = DateTime.UtcNow;
        await cartRepository.UpdateAsync(cart, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<bool> DeleteCartAsync(int cartId, CancellationToken cancellationToken = default)
    {
        var cart =
            await cartRepository.GetAsync(c => c.Id == cartId, cancellationToken: cancellationToken);

        if (cart == null)
            return false;

        await cartRepository.DeleteAsync(cart, cancellationToken);
        return true;
    }
}