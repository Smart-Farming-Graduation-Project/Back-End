namespace Croppilot.Core.Features.Carts.Query.Result;

public record GetCartResponse(
    int CartId,
    Guid UserId,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    List<GetCartItemResponse> CartItems
);