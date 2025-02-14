namespace Croppilot.Core.Features.WishLists.Command.Models;

public class UpdateWishlistCommand : IRequest<Response<string>>
{
    public Guid UserId { get; set; }
    public List<UpdateWishlistItemCommand> WishlistItems { get; set; } = [];
}