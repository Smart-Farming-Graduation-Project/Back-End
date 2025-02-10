namespace Croppilot.Core.Features.Carts.Query.Handlers;

public class CartQueryHandler(ICartService cartService)
    : ResponseHandler, IRequestHandler<GetCartQuery, Response<GetCartResponse>>
{
    public async Task<Response<GetCartResponse>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await cartService.GetCartByUserIdAsync(request.UserId, cancellationToken);
        if (cart == null)
            return NotFound<GetCartResponse>("Cart not found");

        var result = cart.Adapt<GetCartResponse>();
        return Success(result);
    }
}