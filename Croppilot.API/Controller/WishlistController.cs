using Croppilot.API.Bases;
using Croppilot.Core.Features.Authentication.Queries.Models;
using Croppilot.Core.Features.WishLists.Command.Models;
using Croppilot.Core.Features.WishLists.Query.Models;
using Croppilot.Date.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller;

[SwaggerResponse(200, "Operation is done successfully")]
[SwaggerResponse(400, "Invalid operation or something is invalid")]
[SwaggerResponse(401, "User is not authorized to perform this operation")]
[Authorize(Policy = nameof(UserRoleEnum.User))]
public class WishlistController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    : AppControllerBase
{
    /// <summary>
    /// Retrieves the current user's wishlist.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the wishlist data or an error response.</returns>
    [HttpGet("GetWishlist")]
    [SwaggerOperation(Summary = "Retrieves the current user's wishlist",
        Description = "**Fetches the wishlist for the authenticated user.**")]
    public async Task<IActionResult> GetWishlist()
    {
        var username = GetCurrentUserName();

        var userIdResponse = await mediator.Send(new GetCurrentUserIdQuery { UserName = username });
        if (!userIdResponse.Succeeded)
            return NewResult(userIdResponse);

        var userId = userIdResponse.Data;
        var response = await mediator.Send(new GetWishlistQuery { UserId = userId! });
        return NewResult(response);
    }

    /// <summary>
    /// Adds a product to the current user's wishlist.
    /// If the wishlist does not exist, a new one is created.
    /// </summary>
    /// <param name="productId">The ID of the product to add to the wishlist.</param>
    /// <returns>An <see cref="IActionResult"/> indicating whether the product was successfully added or not.</returns>
    [HttpPost("AddProduct/{productId}")]
    [SwaggerOperation(Summary = "Adds a product to the wishlist",
        Description =
            "**Adds a specified product to the user's wishlist.Need ID of the product to add to the wishlist.**")]
    public async Task<IActionResult> AddProductToWishlist([FromRoute] int productId)
    {
        var username = GetCurrentUserName();
        var userIdResponse = await mediator.Send(new GetCurrentUserIdQuery { UserName = username });
        if (!userIdResponse.Succeeded)
            return NewResult(userIdResponse);

        var command = new AddProductToWishlistCommand
        {
            UserId = userIdResponse.Data!,
            ProductId = productId
        };

        var response = await mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Removes a product from the current user's wishlist.
    /// </summary>
    /// <param name="productId">The ID of the product to remove from the wishlist.</param>
    /// <returns>An <see cref="IActionResult"/> indicating whether the product was successfully removed or not.</returns>
    [HttpDelete("RemoveProduct/{productId}")]
    [SwaggerOperation(Summary = "Removes a product from the wishlist",
        Description =
            "**Removes the specified product from the user's wishlist.Need the ID of the product to remove from the wishlist.**")]
    public async Task<IActionResult> RemoveProductFromWishlist([FromRoute] int productId)
    {
        var username = GetCurrentUserName();
        var userIdResponse = await mediator.Send(new GetCurrentUserIdQuery { UserName = username });
        if (!userIdResponse.Succeeded)
            return NewResult(userIdResponse);

        var command = new RemoveProductFromWishlistCommand
        {
            UserId = userIdResponse.Data!,
            ProductId = productId
        };

        var response = await mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Retrieves the current user's username from the HTTP context claims.
    /// </summary>
    /// <returns>The username of the authenticated user.</returns>
    /// <exception cref="UnauthorizedAccessException">Thrown if the user is not authenticated.</exception>
    private string GetCurrentUserName()
    {
        var userNameClaim = httpContextAccessor.HttpContext?.User
            .Claims
            .FirstOrDefault(c => c.Type == "NameIdentifier")?
            .Value;

        if (string.IsNullOrWhiteSpace(userNameClaim))
            throw new UnauthorizedAccessException("User not authenticated");

        return userNameClaim;
    }
}