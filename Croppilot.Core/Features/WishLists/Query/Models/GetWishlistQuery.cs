using Croppilot.Core.Features.WishLists.Query.Result;

namespace Croppilot.Core.Features.WishLists.Query.Models;

public class GetWishlistQuery : IRequest<Response<GetWishlistResponse>>
{
    public Guid UserId { get; set; }
}