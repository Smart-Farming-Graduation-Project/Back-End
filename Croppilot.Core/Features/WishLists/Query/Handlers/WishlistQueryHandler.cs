using Croppilot.Core.Features.WishLists.Query.Models;
using Croppilot.Core.Features.WishLists.Query.Result;

namespace Croppilot.Core.Features.WishLists.Query.Handlers;

public class WishlistQueryHandler(IWishlistService wishlistService) : ResponseHandler,
    IRequestHandler<GetWishlistQuery, Response<GetWishlistResponse>>
{
    public async Task<Response<GetWishlistResponse>> Handle(GetWishlistQuery request, CancellationToken cancellationToken)
    {
        var wishlist = await wishlistService.GetWishlistByUserIdAsync(request.UserId, cancellationToken);
        if (wishlist == null)
            return NotFound<GetWishlistResponse>("Wishlist not found");

        var result = wishlist.Adapt<GetWishlistResponse>();
        return Success(result);
    }
}