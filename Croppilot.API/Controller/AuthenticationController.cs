using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Queries.Models;

namespace Croppilot.API.Controller;

/// <summary>
/// AuthenticationController exposes endpoints for user registration, login, password reset, email confirmation, and third-party authentication.
/// 
/// Each endpoint returns a standardized response with:
/// - StatusCode: The HTTP status code of the response.
/// - Succeeded: A boolean indicating if the operation was successful.
/// - Message: A brief message for the operation.
/// - Data: The payload data (if applicable).
/// - Errors: A list of errors (if any), where each error contains:
///     - Code: A unique code for the error.
///     - Message: A description of the error.
///     - Field: The field that caused the error (if applicable).
/// 
/// Frontend developers should check the 'Succeeded' flag and, if false, read the 'Errors' list to determine the exact issues.
/// </summary>
[Route("api/[controller]"), ApiController]
[EnableRateLimiting(RateLimiters.AuthenticationEndpointsLimit)]
public class AuthenticationController(IMediator mediator) : AppControllerBase
{
	/// <summary>
	/// Registers a new user.
	/// Frontend: Provide user details (first name, last name, username, email, password, etc.). 
	/// If errors occur (e.g., duplicate email), the response 'Errors' list will contain the problematic field (e.g., "Email").
	/// </summary>
	[HttpPost("Register"), SwaggerResponse(201, "Your account has been created, please confirm your email address"),
	 SwaggerResponse(400,
		 "Bad Request. Possible reasons 'Messages returned': \n- User creation failed \n- Failed to send email. Please contact admin \n- some error in operation it will appear in message 'دي مش الرساله اللي هتظهر انا بوضحكلك'"),
	 SwaggerOperation(
		 Summary = "Registers a new user",
		 Description =
			 "Creates a new user account. **For mobile clients, firstName, lastName, phone, and address are optional. 'سبهم فاضيين عادي'**"
	 )]
	// [SwaggerRequestExample(typeof(AddUserCommand), typeof(RegisterRequestExample))] //Show frontend and mobile request examples
	public async Task<IActionResult> Register([FromForm] AddUserCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Logs in a user.
	/// Frontend: Supply username/email and password.
	/// On failure (e.g., invalid credentials or unconfirmed email), check the 'Errors' for details.
	/// </summary>
	[HttpPost("SignIn"),
	 SwaggerResponse(400,
		 "Bad Request. Possible reasons 'Messages returned': \n- Invalid username or password. \n- Please confirm your email before signing in. \n- Username or Password are wrong \n- others"),
	 SwaggerOperation(
		 Summary = "Log in a user",
		 Description = "**Authenticates a user and returns an access token.**")]
	public async Task<IActionResult> SignIn(SignInCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Refreshes the authentication token.
	/// Frontend: Provide the current refresh token along with the username.
	/// On failure, the error will indicate issues with the "RefreshToken" field.
	/// </summary>
	[HttpPost("RefreshToken"), SwaggerOperation(
		 Summary = "Refreshes the authentication token",
		 Description = "**Generates a new access token using a refresh token.**")]
	public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Revokes a refresh token.
	/// Frontend: Provide the refresh token to be revoked.
	/// On failure, check the 'Errors' for issues with the "RefreshToken" field.
	/// </summary>
	[HttpPost("RevokeToken"), SwaggerOperation(
		 Summary = "Revokes a refresh token",
		 Description = "**Invalidates a user's refresh token to prevent further use.**")]
	public async Task<IActionResult> RevokeToken(RevokeRefreshTokenCommand command)
	{
		return NewResult(await mediator.Send(command));
	}


	/// <summary>
	/// Confirms a user's email address.
	/// Frontend: Pass the confirmation token and email.
	/// On failure, errors may include issues with the "Email" or "Token" fields.
	/// </summary>
	[HttpPut("confirm-email"), SwaggerResponse(200, "Your email address is confirmed. You can login now"),
	 SwaggerResponse(400,
		 "Bad Request. Possible reasons 'Messages returned': \n- This email address has not been registered yet \n- Invalid token. Please try again \n- Your email was confirmed before. Please login to your account"),
	 SwaggerOperation(
		 Summary = "Confirms a user's email",
		 Description = "**Verifies the user's email using a confirmation token.**")]
	public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Resends the email confirmation link.
	/// Frontend: Supply the email address. 
	/// If errors occur (e.g., email not registered or already confirmed), the 'Errors' list will detail the issue.
	/// </summary>
	[HttpPost("resend-email-confirmation-link"), SwaggerOperation(
		 Summary = "Resends the email confirmation link",
		 Description = "**Sends a new confirmation email to the user.**")]
	public async Task<IActionResult> ResendEmailConfirmationLink(ResendConfirmEmailCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Initiates recovery for a forgotten username or password.
	/// Frontend: Provide the registered email.
	/// On failure, errors may specify issues with the "Email" field.
	/// </summary>
	[HttpPost("forgot-username-or-password"), SwaggerOperation(
		 Summary = "Initiates password or username recovery",
		 Description = "**Sends an email to reset the password or retrieve the username.**")]
	public async Task<IActionResult> ForgotUsernameOrPassword(ForgetPasswordCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Resets the user's password using a token.
	/// Frontend: Provide the token (usually from an email link), email, new password, and confirm password.
	/// On failure, errors may include issues with the "Token" or "Email" fields.
	/// </summary>
	[HttpPut("reset-password"), SwaggerResponse(200, "Please check your email"),
	 SwaggerResponse(400,
		 "Bad Request. Possible reasons 'Messages returned': \n- This email address has not been registered yet \n- Please confirm your email address first. \n- Failed to send email. Please contact admin"),
	 SwaggerOperation(
		 Summary = "Resets the user password",
		 Description = "**Allows a user to reset their password using a token.**")]
	public async Task<IActionResult> ResetPassword(ResetPasswordCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Changes the password for a logged-in user.
	/// Frontend: Provide the user Id, current password, new password, and confirm password.
	/// On failure, errors may point to the "Password" field (e.g., if current password is incorrect).
	/// </summary>
	[HttpPut("ChangePassword"), SwaggerOperation(
		 Summary = "Changes the user's password",
		 Description = "**Allows a logged-in user to change their password.**")]
	public async Task<IActionResult> ChangePassword(ChangeUserPasswordCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Initiates recovery using a One-Time Password (OTP).
	/// Frontend: Provide the registered email. An OTP code will be sent to the email.
	/// On failure, errors will detail issues with the "Email" field.
	/// </summary>
	[HttpPost("forgot-username-or-password-using-OTP"), SwaggerOperation(
		 Summary = "Initiates recovery using OTP",
		 Description = "**Sends a One-Time Password (OTP) for recovery.**")]
	public async Task<IActionResult> ForgotUsernameOrPasswordUsingOtpCode(ForgetPasswordUsingOTPCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Resets the password using an OTP code.
	/// Frontend: Provide the OTP code and the registered email.
	/// On failure, errors will include issues with the "Code" or "Email" fields.
	/// </summary>
	[HttpPost("reset-password-otp"), SwaggerOperation(
		 Summary = "Resets password using OTP",
		 Description = "**Allows a user to reset their password using an OTP.**")]
	public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordUsingOTPQuery query)
	{
		return NewResult(await mediator.Send(query));
	}

	/// <summary>
	/// Registers a new user using a third-party authentication provider (e.g., Google or Facebook).
	/// Frontend: Provide first name, last name, access token, and provider.
	/// On failure, errors may include issues with the "Email" or "AccessToken" fields.
	/// </summary>
	[HttpPost("register-with-third-party"), SwaggerOperation(
		 Summary = "Registers using a third-party provider",
		 Description = "**Creates a user account using external authentication providers like Google or Facebook.**")]
	public async Task<IActionResult> RegisterWithThirdParty(RegisterWithExternalCommand command)
	{
		return NewResult(await mediator.Send(command));
	}

	/// <summary>
	/// Logs in a user using a third-party authentication provider.
	/// Frontend: Provide access token and provider.
	/// On failure, errors may include issues with the "AccessToken" field.
	/// </summary>
	[HttpPost("login-with-third-party"), SwaggerOperation(
		 Summary = "Logs in using a third-party provider",
		 Description = "**Authenticates a user using external authentication providers like Google or Facebook.**")]
	public async Task<IActionResult> LoginWithThirdParty(LoginWithExternalCommand command)
	{
		return NewResult(await mediator.Send(command));
	}
}