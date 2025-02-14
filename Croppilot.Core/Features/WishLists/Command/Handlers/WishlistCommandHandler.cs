using Croppilot.Core.Features.WishLists.Command.Models;
using Croppilot.Date.Models;

namespace Croppilot.Core.Features.WishLists.Command.Handlers;

public class WishlistCommandHandler(IWishlistService wishlistService, IProductServices productServices)
    : ResponseHandler,
        IRequestHandler<CreateWishlistCommand, Response<string>>,
        IRequestHandler<UpdateWishlistCommand, Response<string>>,
        IRequestHandler<DeleteWishlistCommand, Response<string>>
{
    public async Task<Response<string>> Handle(CreateWishlistCommand command, CancellationToken cancellationToken)
    {
        var existingWishlist = await wishlistService.GetWishlistByUserIdAsync(command.UserId, cancellationToken);
        if (existingWishlist != null)
            return BadRequest<string>("Wishlist already exists");

        foreach (var item in command.WishlistItems)
        {
            var isProductExist = await IsProductExist(item.ProductId, cancellationToken);
            if (!isProductExist)
                return BadRequest<string>($"Product with ID {item.ProductId} does not exist.");
        }

        var wishlist = new Wishlist
        {
            UserId = command.UserId,
            WishlistItems = command.WishlistItems.Select(i => new WishlistItem
            {
                ProductId = i.ProductId
            }).ToList(),
            CreatedAt = DateTime.UtcNow
        };

        var result = await wishlistService.CreateWishlistAsync(wishlist, cancellationToken);
        return result == OperationResult.Success
            ? Created<string>("Wishlist created successfully")
            : BadRequest<string>("Wishlist creation failed");
    }

    public async Task<Response<string>> Handle(UpdateWishlistCommand command, CancellationToken cancellationToken)
    {
        var wishlist = await wishlistService.GetWishlistByUserIdAsync(command.UserId, cancellationToken);
        if (wishlist == null)
            return NotFound<string>("Wishlist not found");

        // Map updated items (assuming you want to add new items and keep existing ones)
        var existingItems = wishlist.WishlistItems.ToDictionary(i => i.Id);
        var updatedItems = new List<WishlistItem>();

        foreach (var updateItem in command.WishlistItems)
        {
            var isProductExist = await IsProductExist(updateItem.ProductId, cancellationToken);
            if (!isProductExist)
                return BadRequest<string>($"Product with ID {updateItem.ProductId} does not exist.");

            if (updateItem.Id > 0 && existingItems.TryGetValue(updateItem.Id, out var existingItem))
            {
                updatedItems.Add(existingItem);
            }
            else
            {
                updatedItems.Add(new WishlistItem
                {
                    ProductId = updateItem.ProductId,
                    WishlistId = wishlist.Id
                });
            }
        }

        wishlist.WishlistItems = updatedItems;
        var result = await wishlistService.UpdateWishlistAsync(wishlist, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Wishlist updated successfully")
            : BadRequest<string>("Wishlist update failed");
    }

    public async Task<Response<string>> Handle(DeleteWishlistCommand command, CancellationToken cancellationToken)
    {
        var result = await wishlistService.DeleteWishlistAsync(command.WishlistId, cancellationToken);
        return result
            ? Deleted<string>("Wishlist deleted successfully")
            : NotFound<string>("Wishlist not found");
    }

    private async Task<bool> IsProductExist(int productId, CancellationToken cancellationToken)
    {
        var product = await productServices.GetByIdAsync(productId, cancellationToken: cancellationToken);
        return product != null;
    }
}