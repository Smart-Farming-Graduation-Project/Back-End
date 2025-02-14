namespace Croppilot.Core.Features.WishLists.Query.Result;

public record GetWishlistResponse(
    int WishlistId,
    Guid UserId,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    List<GetWishlistItemResponse> WishlistItems
);