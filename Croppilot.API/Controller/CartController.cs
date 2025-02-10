using Croppilot.API.Bases;
using Croppilot.Core.Features.Authentication.Queries.Models; 
using Croppilot.Core.Features.Carts.Command.Models;
using Croppilot.Core.Features.Carts.Query.Models;
using Croppilot.Date.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller
{
    [Authorize(Policy = nameof(UserRoleEnum.User))]
    public class CartController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        : AppControllerBase
    {
        [HttpGet("GetCart")]
        public async Task<IActionResult> GetCart()
        {
            var username = GetCurrentUserName();

            var userIdResponse = await mediator.Send(new GetCurrentUserIdQuery { UserName = username });
            if (!userIdResponse.Succeeded)
                return NewResult(userIdResponse);

            var userId = userIdResponse.Data;
            
            var response = await mediator.Send(new GetCartQuery { UserId = userId });
            return NewResult(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateCartCommand command)
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
        public async Task<IActionResult> Update(UpdateCartCommand command)
        {
            var username = GetCurrentUserName();

            var userIdResponse = await mediator.Send(new GetCurrentUserIdQuery { UserName = username });
            if (!userIdResponse.Succeeded)
                return NewResult(userIdResponse);

            command.UserId = userIdResponse.Data;
            var response = await mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("Delete/{cartId}")]
        public async Task<IActionResult> Delete([FromRoute] int cartId)
        {
            var response = await mediator.Send(new DeleteCartCommand(cartId));
            return NewResult(response);
        }

        /// <summary>
        /// Retrieves the current user's username from the claims.
        /// </summary>
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
}
