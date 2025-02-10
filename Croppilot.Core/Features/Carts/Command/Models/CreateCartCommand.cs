namespace Croppilot.Core.Features.Carts.Command.Models;

public class CreateCartCommand : IRequest<Response<string>>
{
    public Guid UserId { get; set; }
    public List<CreateCartItemCommand> CartItems { get; set; } = new();
}