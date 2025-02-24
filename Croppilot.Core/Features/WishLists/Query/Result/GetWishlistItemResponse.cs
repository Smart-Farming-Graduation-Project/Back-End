namespace Croppilot.Core.Features.WishLists.Query.Result;

public record GetWishlistItemResponse(
    int Id,
    int ProductId,
    string ProductName,
    string ProductDescription,
    string ProductAvailability,
    decimal ProductPrice,
    List<string> ProductImages
);