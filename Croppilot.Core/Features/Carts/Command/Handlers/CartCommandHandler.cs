using Croppilot.Core.Features.Carts.Command.Models;
using Croppilot.Date.Models;

namespace Croppilot.Core.Features.Carts.Command.Handlers;

public class CartCommandHandler(ICartService cartService, IProductServices productServices) : ResponseHandler,
    IRequestHandler<CreateCartCommand, Response<string>>,
    IRequestHandler<UpdateCartCommand, Response<string>>,
    IRequestHandler<DeleteCartCommand, Response<string>>
{
    public async Task<Response<string>> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        
        var existingCart = await cartService.GetCartByUserIdAsync(command.UserId, cancellationToken);
        if (existingCart != null)
            return BadRequest<string>("Cart already exists");
        
        foreach (var item in command.CartItems)
        {
            var isProductExist = await IsProductExist(item.ProductId, cancellationToken: cancellationToken);
            if (!isProductExist)
                return BadRequest<string>($"Product with ID {item.ProductId} does not exist.");
        }
        
        var cart = new Cart
        {
            UserId = command.UserId,
            CartItems = command.CartItems.Select(item => new CartItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity
            }).ToList(),
            CreatedAt = DateTime.UtcNow
        };

        var result = await cartService.CreateCartAsync(cart, cancellationToken);
        return result == OperationResult.Success
            ? Created<string>("Cart created successfully")
            : BadRequest<string>("Cart creation failed");
    }

    public async Task<Response<string>> Handle(UpdateCartCommand command, CancellationToken cancellationToken)
    {
        var cart = await cartService.GetCartByUserIdAsync(command.UserId, cancellationToken);
        if (cart == null)
            return NotFound<string>("Cart not found");

        var existingItems = cart.CartItems.ToDictionary(item => item.Id);

        var updatedItems = new List<CartItem>();

        foreach (var updateItem in command.CartItems)
        {
            var isProductExist = await IsProductExist(updateItem.ProductId, cancellationToken);

            if (!isProductExist)
                return BadRequest<string>($"Product with ID {updateItem.ProductId} does not exist.");

            if (updateItem.Id > 0)
            {
                if (existingItems.TryGetValue(updateItem.Id, out var existingItem))
                {
                    existingItem.Quantity = updateItem.Quantity;
                    updatedItems.Add(existingItem);
                }
                else
                {
                    updatedItems.Add(new CartItem
                    {
                        ProductId = updateItem.ProductId,
                        Quantity = updateItem.Quantity,
                        CartId = cart.Id
                    });
                }
            }
            else
            {
                updatedItems.Add(new CartItem
                {
                    ProductId = updateItem.ProductId,
                    Quantity = updateItem.Quantity,
                    CartId = cart.Id
                });
            }
        }

        cart.CartItems = updatedItems;

        var result = await cartService.UpdateCartAsync(cart, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Cart updated successfully")
            : BadRequest<string>("Cart update failed");
    }

    public async Task<Response<string>> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        var result = await cartService.DeleteCartAsync(command.CartId, cancellationToken);
        return result ? Deleted<string>("Cart deleted successfully") : NotFound<string>("Cart not found");
    }

    private async Task<bool> IsProductExist(int productId, CancellationToken cancellationToken)
    {
        var product = await productServices.GetByIdAsync(productId, cancellationToken: cancellationToken);
        return product != null;
    }
}