using Croppilot.API.Bases;
using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerResponse(200, "Operation Is Done successfully")]
    [SwaggerResponse(400, "Invalid Operation Or Somthing is Invalid")]
    public class AuthenticationController : AppControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        [SwaggerOperation(Summary = "Registers a new user", Description = "**Creates a new user account with the provided details.**")]
        public async Task<IActionResult> Register(AddUserCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost("SignIn")]
        [SwaggerOperation(Summary = "Log in a user", Description = "**Authenticates a user and returns an access token.'عمليه تسجيل الدخول'**")]
        public async Task<IActionResult> SignIn(SignInCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost("RefreshToken")]
        [SwaggerOperation(Summary = "Refreshes the authentication token", Description = "**Generates a new access token using a refresh token.**")]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost("RevokeToken")]
        [SwaggerOperation(Summary = "Revokes a refresh token", Description = "**Invalidates a user's refresh token to prevent further use.**")]
        public async Task<IActionResult> RevokeToken(RevokeRefreshTokenCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPut("confirm-email")]
        [SwaggerOperation(Summary = "Confirms a user's email", Description = "**Verifies the user's email using a confirmation token.**")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost("resend-email-confirmation-link")]
        [SwaggerOperation(Summary = "Resends the email confirmation link", Description = "**Sends a new confirmation email to the user.**")]
        public async Task<IActionResult> ResendEmailConfirmationLink(ResendConfirmEmailCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost("forgot-username-or-password")]
        [SwaggerOperation(Summary = "Initiates password or username recovery", Description = "**Sends an email to reset the password or retrieve the username.**")]
        public async Task<IActionResult> ForgotUsernameOrPassword(ForgetPasswordCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPut("reset-password")]
        [SwaggerOperation(Summary = "Resets the user password", Description = "**Allows a user to reset their password using a token.**")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPut("ChangePassword")]
        [SwaggerOperation(Summary = "Changes the user's password", Description = "**Allows a logged-in user to change their password.**")]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost("forgot-username-or-password-using-OTP")]
        [SwaggerOperation(Summary = "Initiates recovery using OTP", Description = "**Sends a One-Time Password (OTP) for recovery.**")]
        public async Task<IActionResult> ForgotUsernameOrPasswordUsingOtpCode(ForgetPasswordUsingOTPCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost("reset-password-otp")]
        [SwaggerOperation(Summary = "Resets password using OTP", Description = "**Allows a user to reset their password using an OTP.**")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordUsingOTPQuery query)
        {
            return NewResult(await _mediator.Send(query));
        }

        [HttpPost("register-with-third-party")]
        [SwaggerOperation(Summary = "Registers using a third-party provider", Description = "**Creates a user account using external authentication providers like Google or Facebook.**")]
        public async Task<IActionResult> RegisterWithThirdParty(RegisterWithExternalCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost("login-with-third-party")]
        [SwaggerOperation(Summary = "Logs in using a third-party provider", Description = "**Authenticates a user using external authentication providers like Google or Facebook.**")]
        public async Task<IActionResult> LoginWithThirdParty(LoginWithExternalCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }
    }
}
