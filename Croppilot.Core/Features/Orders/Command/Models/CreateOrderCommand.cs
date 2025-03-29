using Croppilot.Core.Features.Orders.Command.Result;

namespace Croppilot.Core.Features.Orders.Command.Models;

public class CreateOrderCommand : IRequest<Response<CreateOrderResponse>>
{
	/* todo : Fix later :
     Issue: The current implementation allows users to manipulate other users' carts by specifying any UserId in requests
    Remove UserId from end point and request body.
    Instead, retrieve the authenticated user's ID from the request context (JWT claims).
    Modify the controller to infer UserId from the authenticated user:
    // Example using HttpContext.User
    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
*/
	/*
        Done: UserId removed from the request body.
     */

	public string ShippingAddress { get; set; } = string.Empty;
	public List<CreateOrderItemCommand> OrderItems { get; set; } = new();
}