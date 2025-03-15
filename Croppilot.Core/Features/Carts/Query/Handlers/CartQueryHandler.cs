using Croppilot.Date.Models;

namespace Croppilot.Core.Features.Carts.Query.Handlers;

public class CartQueryHandler(ICartService cartService)
    : ResponseHandler, IRequestHandler<GetCartQuery, Response<GetCartResponse>>
{
    public async Task<Response<GetCartResponse>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await cartService.GetCartByUserIdAsync(request.UserId, cancellationToken) ?? new Cart
        {
            UserId = request.UserId,
            CreatedAt = DateTime.UtcNow,
            CartItems = new List<CartItem>()
        };

        var result = cart.Adapt<GetCartResponse>();
        return Success(result);
    }
}