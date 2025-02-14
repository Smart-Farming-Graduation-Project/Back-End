namespace Croppilot.Core.Features.WishLists.Command.Models;

public class CreateWishlistCommand : IRequest<Response<string>>
{
    public Guid UserId { get; set; }
    public List<CreateWishlistItemCommand> WishlistItems { get; set; } = new();
}
