using Croppilot.Core.Features.Orders.Command.Models;
using Croppilot.Core.Features.Orders.Command.Result;
using Croppilot.Date.Models;
using System.Security.Claims;

namespace Croppilot.Core.Features.Orders.Command.Handlers;

public class OrderCommandHandler(
	IOrderService orderService,
	IProductServices productService,
	ICuponService cuponService,
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
			Date.Models.Cupon? cupon = null;
			var product = await productService.GetByIdAsync(item.ProductId, cancellationToken: cancellationToken);
			if (product is null)
				return BadRequest<CreateOrderResponse>($"Product with ID {item.ProductId} does not exist.");
			if (item.Cupon is not null)
			{
				cupon = await cuponService.GetCuponByCodeAsync(item.Cupon, tracked: true);
				if (cupon is null || !cupon.IsActive || product.CuponId != cupon.Id)
					return BadRequest<CreateOrderResponse>($"{item.Cupon} is invalid");
				cupon.UsageCount++;
			}
			decimal discount = cupon?.Discount_Type switch
			{
				Discount_Type.Percentage => product.Price * cupon.Discount_Value / 100,
				Discount_Type.Fixed => cupon.Discount_Value,
				_ => 0
			};
			var itemPrice = product.Price - discount;
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