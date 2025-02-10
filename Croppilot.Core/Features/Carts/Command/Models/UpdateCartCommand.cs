namespace Croppilot.Core.Features.Carts.Command.Models;

public class UpdateCartCommand : IRequest<Response<string>>
{
    public Guid UserId { get; set; }
    public List<UpdateCartItemCommand> CartItems { get; set; } = [];
}