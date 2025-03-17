using Croppilot.Core.Features.Carts.Command.Models;
using Croppilot.Date.Models;

namespace Croppilot.Core.Features.Carts.Command.Handlers;

public class CartCommandHandler(ICartService cartService) : ResponseHandler,
    IRequestHandler<AddProductToCartCommand, Response<string>>,
    IRequestHandler<RemoveProductFromCartCommand, Response<string>>
{
    public async Task<Response<string>> Handle(AddProductToCartCommand command, CancellationToken cancellationToken)
    {
        var cart = await cartService.GetCartByUserIdAsync(command.UserId, cancellationToken) ?? new Cart
        {
            UserId = command.UserId,
            CreatedAt = DateTime.UtcNow,
            CartItems = new List<CartItem>()
        };
        
        var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == command.ProductId);
        if (existingItem != null)
        {
            // Increase the quantity.
            existingItem.Quantity += command.Quantity;
        }
        else
        {
            // Add new cart item.
            cart.CartItems.Add(new CartItem
            {
                ProductId = command.ProductId,
                Quantity = command.Quantity
            });
        }

        OperationResult result;
        if (cart.Id == 0)
            result = await cartService.CreateCartAsync(cart, cancellationToken);
        else
            result = await cartService.UpdateCartAsync(cart, cancellationToken);

        return result == OperationResult.Success
            ? Success<string>("Product added to cart successfully.")
            : BadRequest<string>("Failed to add product to cart.");
    }
    
    public async Task<Response<string>> Handle(RemoveProductFromCartCommand command,
        CancellationToken cancellationToken)
    {
        var cart = await cartService.GetCartByUserIdAsync(command.UserId, cancellationToken);
        if (cart == null)
            return NotFound<string>("Cart not found");

        var itemToRemove = cart.CartItems.FirstOrDefault(ci => ci.ProductId == command.ProductId);
        if (itemToRemove == null)
            return NotFound<string>($"Product with ID {command.ProductId} not found in cart.");

        cart.CartItems.Remove(itemToRemove);

        var result = await cartService.UpdateCartAsync(cart, cancellationToken);
        return result == OperationResult.Success
            ? Success<string>("Product removed from cart successfully.")
            : BadRequest<string>("Failed to remove product from cart.");
    }
}