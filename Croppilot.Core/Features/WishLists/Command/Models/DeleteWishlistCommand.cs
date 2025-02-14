namespace Croppilot.Core.Features.WishLists.Command.Models;

public class DeleteWishlistCommand(int wishlistId) : IRequest<Response<string>>
{
    public int WishlistId { get; set; } = wishlistId;
}