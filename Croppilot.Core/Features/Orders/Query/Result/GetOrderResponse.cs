namespace Croppilot.Core.Features.Orders.Query.Result;

public record GetOrderResponse(
    int OrderId,
    string UserId,
    string ShippingAddress,
    DateTime OrderDate,
    string Status,
    decimal TotalAmount,
    List<GetOrderItemResponse> OrderItems
);

