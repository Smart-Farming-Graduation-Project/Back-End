namespace Croppilot.Core.Features.Carts.Command.Models;

public class AddProductToCartCommand : IRequest<Response<string>>
{
    public string UserId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; } = 1;
}