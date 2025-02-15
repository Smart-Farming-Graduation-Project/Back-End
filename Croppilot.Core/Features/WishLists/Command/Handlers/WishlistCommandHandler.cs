using Croppilot.Core.Features.WishLists.Command.Models;
using Croppilot.Date.Models;

namespace Croppilot.Core.Features.WishLists.Command.Handlers;

public class WishlistCommandHandler(IWishlistService wishlistService, IProductServices productServices)
    : ResponseHandler,
        IRequestHandler<AddProductToWishlistCommand, Response<string>>,
        IRequestHandler<RemoveProductFromWishlistCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddProductToWishlistCommand command, CancellationToken cancellationToken)
    {
        var isProductExist = await IsProductExist(command.ProductId, cancellationToken);
        if (!isProductExist)
            return BadRequest<string>($"Product with ID {command.ProductId} does not exist.");

        var wishlist = await wishlistService.GetWishlistByUserIdAsync(command.UserId, cancellationToken) ?? new Wishlist
        {
            UserId = command.UserId,
            CreatedAt = DateTime.UtcNow,
            WishlistItems = new List<WishlistItem>()
        };


        if (wishlist.WishlistItems.Any(item => item.ProductId == command.ProductId))
            return BadRequest<string>($"Product with ID {command.ProductId} is already in your wishlist.");

        wishlist.WishlistItems.Add(new WishlistItem
        {
            ProductId = command.ProductId,
            CreatedAt = DateTime.UtcNow
        });

        OperationResult result;
        if (wishlist.Id == 0)
            result = await wishlistService.CreateWishlistAsync(wishlist, cancellationToken);
        else
            result = await wishlistService.UpdateWishlistAsync(wishlist, cancellationToken);

        return result == OperationResult.Success
            ? Success<string>("Product added to wishlist successfully.")
            : BadRequest<string>("Failed to add product to wishlist.");
    }

    public async Task<Response<string>> Handle(RemoveProductFromWishlistCommand command,
        CancellationToken cancellationToken)
    {
        var wishlist = await wishlistService.GetWishlistByUserIdAsync(command.UserId, cancellationToken);
        if (wishlist == null)
            return NotFound<string>("Wishlist not found");

        var itemToRemove = wishlist.WishlistItems.FirstOrDefault(item => item.ProductId == command.ProductId);
        if (itemToRemove == null)
            return NotFound<string>($"Product with ID {command.ProductId} not found in wishlist.");

        wishlist.WishlistItems.Remove(itemToRemove);

        var result = await wishlistService.UpdateWishlistAsync(wishlist, cancellationToken);
        
        return result == OperationResult.Success
            ? Success<string>("Product removed from wishlist successfully.")
            : BadRequest<string>("Failed to remove product from wishlist.");
    }

    private async Task<bool> IsProductExist(int productId, CancellationToken cancellationToken)
    {
        var product = await productServices.GetByIdAsync(productId, cancellationToken: cancellationToken);
        return product != null;
    }
}