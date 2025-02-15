namespace Croppilot.Core.Features.WishLists.Command.Models;

public class AddProductToWishlistCommand : IRequest<Response<string>>
{
    public string UserId { get; set; }
    public int ProductId { get; set; }
}