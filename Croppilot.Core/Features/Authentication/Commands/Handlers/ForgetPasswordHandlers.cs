using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;


namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class ForgetPasswordHandlers(
    UserManager<ApplicationUser> userManager,
    IEmailService emailService)
    : ResponseHandler,
        IRequestHandler<ForgetPasswordCommand, Response<string>>,
        IRequestHandler<ResetPasswordCommand, Response<string>>
{
    public async Task<Response<string>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {
        // Validate that the email is provided
        if (string.IsNullOrEmpty(request.Email))
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "InvalidEmail",
                    Message = "Email cannot be empty",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Invalid email");
        }

        // Retrieve user by email
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "EmailNotRegistered",
                    Message = "This email address has not been registered yet",
                    Field = "Email"
                }
            };
            return NotFound<string>(errors, "Email not registered");
        }

        // Ensure that the email is confirmed
        if (!user.EmailConfirmed)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "EmailNotConfirmed",
                    Message = "Please confirm your email address first.",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Email not confirmed");
        }

        // Attempt to send the forgot password email
        try
        {
            if (await emailService.SendForgotUsernameOrPasswordEmail(user))
            {
                return Success("Forgot username or password email sent", "Please check your email");
            }
            else
            {
                var errors = new List<Error>
                {
                    new Error
                    {
                        Code = "EmailSendingError",
                        Message = "Failed to send email. Please contact admin",
                        Field = "Email"
                    }
                };
                return BadRequest<string>(errors, "Email sending error");
            }
        }
        catch (Exception ex)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "EmailSendingException",
                    Message = $"Failed to send email. Please contact admin. Error: {ex.Message}",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Email sending error");
        }
    }

    public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        // Retrieve user by email
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "EmailNotRegistered",
                    Message = "This email address has not been registered yet",
                    Field = "Email"
                }
            };
            return NotFound<string>(errors, "Email not registered");
        }

        // Ensure that the email is confirmed
        if (!user.EmailConfirmed)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "EmailNotConfirmed",
                    Message = "Please confirm your email address first",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Email not confirmed");
        }

        try
        {
            // Decode the token
            var decodedTokenBytes = WebEncoders.Base64UrlDecode(request.Token);
            var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);

            // Attempt to reset the password
            var result = await userManager.ResetPasswordAsync(user, decodedToken, request.NewPassword);
            if (result.Succeeded)
            {
                return Success("Password reset success", "Your password has been reset");
            }

            var errorDescription = result.Errors.FirstOrDefault()?.Description ?? "Password reset failed";
            var errors = new List<Error>
            {
                new()
                {
                    Code = "ResetPasswordError",
                    Message = errorDescription,
                    Field = "Token"
                }
            };
            return BadRequest<string>(errors, "Invalid token");
        }
        catch (Exception ex)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "TokenError",
                    Message = $"Invalid token. Please try again. Error: {ex.Message}",
                    Field = "Token"
                }
            };
            return BadRequest<string>(errors, "Invalid token");
        }
    }
}