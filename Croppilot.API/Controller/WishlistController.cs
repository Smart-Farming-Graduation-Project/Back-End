using Croppilot.API.Bases;
using Croppilot.Core.Features.Authentication.Queries.Models;
using Croppilot.Core.Features.WishLists.Command.Models;
using Croppilot.Core.Features.WishLists.Query.Models;
using Croppilot.Date.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller;

[Authorize(Policy = nameof(UserRoleEnum.User))]
public class WishlistController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    : AppControllerBase
{
    [HttpGet("GetWishlist")]
    public async Task<IActionResult> GetWishlist()
    {
        var username = GetCurrentUserName();

        var userIdResponse = await mediator.Send(new GetCurrentUserIdQuery { UserName = username });
        if (!userIdResponse.Succeeded)
            return NewResult(userIdResponse);

        var userId = userIdResponse.Data;
        var response = await mediator.Send(new GetWishlistQuery { UserId = userId });
        return NewResult(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateWishlistCommand command)
    {
        var username = GetCurrentUserName();

        var userIdResponse = await mediator.Send(new GetCurrentUserIdQuery { UserName = username });
        if (!userIdResponse.Succeeded)
            return NewResult(userIdResponse);

        command.UserId = userIdResponse.Data;
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateWishlistCommand command)
    {
        var username = GetCurrentUserName();

        var userIdResponse = await mediator.Send(new GetCurrentUserIdQuery { UserName = username });
        if (!userIdResponse.Succeeded)
            return NewResult(userIdResponse);

        command.UserId = userIdResponse.Data;
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("Delete/{wishlistId}")]
    public async Task<IActionResult> Delete([FromRoute] int wishlistId)
    {
        var response = await mediator.Send(new DeleteWishlistCommand(wishlistId));
        return NewResult(response);
    }

    private string GetCurrentUserName()
    {
        var userNameClaim = httpContextAccessor.HttpContext?.User?
            .Claims?
            .FirstOrDefault(c => c.Type == "NameIdentifier")?
            .Value;

        if (string.IsNullOrWhiteSpace(userNameClaim))
            throw new UnauthorizedAccessException("User not authenticated");

        return userNameClaim;
    }
}