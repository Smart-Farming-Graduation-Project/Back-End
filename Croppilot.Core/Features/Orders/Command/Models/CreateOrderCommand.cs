namespace Croppilot.Core.Features.Orders.Command.Models;

public class CreateOrderCommand : IRequest<Response<string>>
{
    public string UserId { get; set; }
    public string ShippingAddress { get; set; } = string.Empty;
    public List<CreateOrderItemCommand> OrderItems { get; set; } = new();
}
