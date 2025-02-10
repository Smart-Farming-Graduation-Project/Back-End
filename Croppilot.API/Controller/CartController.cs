using System.Security.Claims;
using Croppilot.API.Bases;
using Croppilot.Core.Features.Carts.Command.Models;
using Croppilot.Core.Features.Carts.Query.Models;
using Croppilot.Date.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller;

[Authorize(Policy = nameof(UserRoleEnum.User))]
public class CartController(IMediator mediator, IHttpContextAccessor httpContextAccessor) : AppControllerBase
{
    [HttpGet("GetCart")]
    public async Task<IActionResult> GetCart()
    {
        var userId = GetCurrentUserId();
        var response = await mediator.Send(new GetCartQuery { UserId = userId });
        return NewResult(response);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateCartCommand command)
    {
        command.UserId = GetCurrentUserId();
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateCartCommand command)
    {
        command.UserId = GetCurrentUserId();
        var response = await mediator.Send(command);
        return NewResult(response);
    }
    
    private Guid GetCurrentUserId()
    {
        var userIdClaim = httpContextAccessor.HttpContext?.User
            .FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        return userIdClaim != null 
            ? Guid.Parse(userIdClaim) 
            : throw new UnauthorizedAccessException("User not authenticated");
    }

}