using Croppilot.Core.Features.Carts.Command.Models;
using Croppilot.Core.Features.Carts.Query.Models;


namespace Croppilot.API.Controller;

/// <summary>
/// Controller responsible for handling shopping cart operations such as retrieving the cart,
/// adding a product to the cart, and removing a product from the cart.
/// </summary>
[SwaggerResponse(200, "Operation is done successfully")]
[SwaggerResponse(400, "Invalid operation or something is invalid")]
[SwaggerResponse(401, "User is not authorized to perform this operation")]
[Authorize(Policy = nameof(UserRoleEnum.User))]
public class CartController : AppControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CartController"/> class.
    /// </summary>
    /// <param name="mediator">The MediatR mediator instance used to send commands and queries.</param>
    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves the current user's shopping cart.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the cart data or an error response.</returns>
    [ResponseCache(CacheProfileName = "Default")]
    [HttpGet("GetCart")]
    [SwaggerOperation(Summary = "Retrieves the current user's cart",
        Description = "**Fetches the shopping cart for the authenticated user.**")]
    public async Task<IActionResult> GetCart()
    {
        var userId = User.GetUserId();
        var response = await _mediator.Send(new GetCartQuery { UserId = userId! });
        return NewResult(response);
    }

    /// <summary>
    /// Adds a product to the current user's shopping cart. 
    /// If the cart does not exist, a new one will be created.
    /// </summary>
    /// <param name="productId">The ID of the product to add.</param>
    /// <param name="quantity">Optional. The number of units to add (default is 1).</param>
    /// <returns>An <see cref="IActionResult"/> indicating whether the product was successfully added.</returns>
    [HttpPost("AddProduct/{productId}")]
    [SwaggerOperation(Summary = "Add a product to the cart",
        Description =
            "**Adds a specified product to the authenticated user's shopping cart. Provide the product ID and optionally specify the quantity (default is 1).**")]
    public async Task<IActionResult> AddProductToCart([FromRoute] int productId, [FromQuery] int quantity = 1)
    {
        var command = new AddProductToCartCommand
        {
            UserId = User.GetUserId()!,
            ProductId = productId,
            Quantity = quantity
        };

        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Removes a product from the current user's shopping cart.
    /// </summary>
    /// <param name="productId">The ID of the product to remove from the cart.</param>
    /// <returns>An <see cref="IActionResult"/> indicating whether the product was successfully removed.</returns>
    [HttpDelete("RemoveProduct/{productId}")]
    [SwaggerOperation(Summary = "Removes a product from the cart",
        Description =
            "**Removes the specified product from the user's shopping cart.Need the The ID of the product to remove from the cart.**")]
    public async Task<IActionResult> RemoveProductFromCart([FromRoute] int productId)
    {
        var command = new RemoveProductFromCartCommand
        {
            UserId = User.GetUserId()!,
            ProductId = productId
        };

        var response = await _mediator.Send(command);
        return NewResult(response);
    }
}