namespace Croppilot.Core.Features.WishLists.Query.Result;

public record GetWishlistItemResponse(
    int Id,
    int ProductId,
    string ProductName,
    decimal ProductPrice
);