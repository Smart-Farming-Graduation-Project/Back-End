
namespace Croppilot.Services.Abstract;

public interface ICartService
{
    Task<OperationResult> CreateCartAsync(Cart cart, CancellationToken cancellationToken = default);
    Task<Cart?> GetCartByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<OperationResult> UpdateCartAsync(Cart cart, CancellationToken cancellationToken = default);
    Task<bool> DeleteCartAsync(int cartId, CancellationToken cancellationToken = default);
}