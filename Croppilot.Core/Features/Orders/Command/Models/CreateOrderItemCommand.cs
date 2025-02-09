namespace Croppilot.Core.Features.Orders.Command.Models;

public class CreateOrderItemCommand
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
