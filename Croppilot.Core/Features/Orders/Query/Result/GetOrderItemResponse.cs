namespace Croppilot.Core.Features.Orders.Query.Result;

public record GetOrderItemResponse(
    int Id,
    int ProductId,
    int Quantity,
    decimal UnitPrice
);