using Croppilot.API.Bases;
using Croppilot.Core.Featuers.Authentication.Commands.Models;
using Croppilot.Core.Featuers.Authentication.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : AppControllerBase
	{
		private readonly IMediator _mediator;
		public AuthenticationController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register(AddUserCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}

		[HttpPost("SignIn")]
		public async Task<IActionResult> SignIn(SignInCommand command)
		{
			return NewResult(await _mediator.Send(command));
			//var response = await _mediator.Send(command);
			//if (response.Succeeded)
			//	SetRefreshTokenInCookie(response.Data.Tokens.RefreshToken, response.Data.Tokens.RefreshTokenExpiration);
			//return NewResult(response);
		}

		[HttpPost("RefreshToken")]
		public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}

		[HttpPost("RevokeToken")]
		public async Task<IActionResult> RevokeToken(RevokeRefreshTokenCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}

		[HttpGet("GetUsers")]
		public async Task<IActionResult> GetPaginatedUsers([FromQuery] int pageNumber, int pageSize)
		{
			return Ok(await _mediator.Send(new GetUserPaginatedQuery(pageNumber, pageSize)));
		}

		[HttpGet("GetById/{id:guid}")]
		public async Task<IActionResult> GetById(string id)
		{
			var response = await _mediator.Send(new GetUserByIdQuery(id));
			return NewResult(response);
		}

		[HttpGet("GetByName/{userName:alpha}")]
		public async Task<IActionResult> GetByName(string userName)
		{
			var response = await _mediator.Send(new GetUserByUserNameQuery(userName));
			return NewResult(response);
		}

		[HttpPut("Edit")]
		public async Task<IActionResult> EditUser(EditUserCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}

		[HttpDelete("Delete/{id:guid}")]
		public async Task<IActionResult> Delete(string id)
		{
			return NewResult(await _mediator.Send(new DeleteUserCommand(id)));
		}

		[HttpPut("ChangePassword")]
		public async Task<IActionResult> ChangePassword(ChangeUserPasswordCommand command)
		{
			return NewResult(await _mediator.Send(command));
		}

		//private void SetRefreshTokenInCookie(string refreshToken, DateTime expireDate)
		//{
		//	var cookieOptions = new CookieOptions()
		//	{
		//		HttpOnly = true,
		//		Expires = expireDate.ToLocalTime()
		//	};
		//	Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);
		//}
	}
}
