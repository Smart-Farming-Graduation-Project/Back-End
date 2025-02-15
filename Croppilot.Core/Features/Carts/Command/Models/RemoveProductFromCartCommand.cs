namespace Croppilot.Core.Features.Carts.Command.Models;

public class RemoveProductFromCartCommand : IRequest<Response<string>>
{
    public string UserId { get; set; }
    public int ProductId { get; set; }
}