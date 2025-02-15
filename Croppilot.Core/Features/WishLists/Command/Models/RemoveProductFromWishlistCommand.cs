namespace Croppilot.Core.Features.WishLists.Command.Models;

public class RemoveProductFromWishlistCommand : IRequest<Response<string>>
{
    public string UserId { get; set; }
    public int ProductId { get; set; }
}