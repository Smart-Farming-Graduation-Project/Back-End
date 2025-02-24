namespace Croppilot.Core.Features.Carts.Query.Result;

public record GetCartItemResponse(
    int Id,
    int ProductId,
    string ProductName,
    string ProductDescription,
    decimal ProductPrice,
    string ProductAvailability,
    int Quantity,
    List<string> ProductImages
);