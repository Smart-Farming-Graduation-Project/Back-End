namespace Croppilot.Core.Features.Carts.Command.Models;

public class CreateCartItemCommand
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}