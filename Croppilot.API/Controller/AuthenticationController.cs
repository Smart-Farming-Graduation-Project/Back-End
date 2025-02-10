using Croppilot.API.Bases;
using Croppilot.Core.Features.Authentication.Commands.Models;
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


        [HttpPut("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
        [HttpPost("resend-email-confirmation-link")]
        public async Task<IActionResult> ResendEmailConfirmationLink(ResendConfirmEmailCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }


        [HttpPost("forgot-username-or-password")]
        public async Task<IActionResult> ForgotUsernameOrPassword(ForgetPasswordCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost("forgot-username-or-password-using-OTP")]
        public async Task<IActionResult> ForgotUsernameOrPasswordUsingOtpCode(ForgetPasswordUsingOTPCommand command)
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
