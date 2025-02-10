namespace Croppilot.Core.Features.Carts.Query.Result;

public record GetCartItemResponse(
    int Id,
    int ProductId,
    string ProductName,
    decimal ProductPrice,
    int Quantity
);