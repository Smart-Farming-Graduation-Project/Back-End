namespace Croppilot.Core.Features.Orders.Command.Models;

public class UpdateOrderCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public string ShippingAddress { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    
    // todo: i assume user cant update order items he can only update the status and shipping address
}