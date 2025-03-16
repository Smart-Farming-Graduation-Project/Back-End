using Croppilot.Core.Features.Orders.Command.Models;
using Croppilot.Core.Features.Orders.Command.Result;
using Croppilot.Date.Models;
using System.Security.Claims;

namespace Croppilot.Core.Features.Orders.Command.Handlers;

public class OrderCommandHandler(
	IOrderService orderService,
	IProductServices productService,
	IHttpContextAccessor httpContextAccessor
) : ResponseHandler,
	IRequestHandler<CreateOrderCommand, Response<CreateOrderResponse>>,
	IRequestHandler<UpdateOrderCommand, Response<string>>,
	IRequestHandler<DeleteOrderCommand, Response<string>>
{
	public async Task<Response<CreateOrderResponse>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
	{
		var totalAmount = 0m;
		var orderItems = new List<OrderItem>();

		foreach (var item in command.OrderItems)
		{
			var product = await productService.GetByIdAsync(item.ProductId, cancellationToken: cancellationToken);
			if (product is null)
				return BadRequest<CreateOrderResponse>($"Product with ID {item.ProductId} does not exist.");

			var itemPrice = product.Price;
			totalAmount += itemPrice * item.Quantity;

			orderItems.Add(new OrderItem
			{
				ProductId = item.ProductId,
				Quantity = item.Quantity,
				UnitPrice = itemPrice
			});
		}
		var userId = httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
		if (string.IsNullOrEmpty(userId))
			return NotFound<CreateOrderResponse>("User not found");
		var order = new Order
		{
			UserId = userId,
			ShippingAddress = command.ShippingAddress,
			Status = OrderStatus.Pending,
			TotalAmount = totalAmount,
			OrderItems = orderItems,
			CreatedAt = DateTime.UtcNow
		};

		var result = await orderService.CreateAsync(order, cancellationToken);

		return result == OperationResult.Success
			? Created<CreateOrderResponse>(new()
			{
				OrderId = order.Id,
				OrderStatus = order.Status,
				TotalAmount = totalAmount
			}
			)
			: BadRequest<CreateOrderResponse>("Order creation failed");
	}

	public async Task<Response<string>> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
	{
		var existingOrder = await orderService.GetByIdAsync(command.Id,
			includeProperties: ["OrderItems"], cancellationToken: cancellationToken);

		if (existingOrder == null)
			return NotFound<string>("Order not found");

		existingOrder.ShippingAddress = command.ShippingAddress;
		existingOrder.Status = command.Status;
		existingOrder.UpdatedAt = DateTime.UtcNow;

		//todo: Optionally, if the order items can be updated as well,
		// recalculate the TotalAmount here by summing over the order items.
		// In this example, i assume order items remain unchanged.

		var result = await orderService.UpdateAsync(existingOrder, cancellationToken);
		return result == OperationResult.Success
			? Success<string>("Order updated successfully")
			: BadRequest<string>("Order update failed");
	}

	public async Task<Response<string>> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
	{
		var result = await orderService.DeleteAsync(command.Id, cancellationToken);

		return result
			? Deleted<string>("Order deleted successfully")
			: NotFound<string>("Order not found");
	}
}