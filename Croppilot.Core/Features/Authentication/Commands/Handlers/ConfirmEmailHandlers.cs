using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;


namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class ConfirmEmailHandlers(
    UserManager<ApplicationUser> userManager,
    IEmailService emailService)
    : ResponseHandler,
        IRequestHandler<ConfirmEmailCommand, Response<string>>,
        IRequestHandler<ResendConfirmEmailCommand, Response<string>>
{
    public async Task<Response<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        // Check if the email is registered
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            var errors = new List<Error>
            {
                new()
                {
                    Code = "EmailNotRegistered",
                    Message = "This email address has not been registered yet",
                    Field = "Email"
                }
            };
            return NotFound<string>(errors, "Email not registered");
        }

        // Check if the email is already confirmed
        if (user.EmailConfirmed)
        {
            var errors = new List<Error>
            {
                new()
                {
                    Code = "EmailAlreadyConfirmed",
                    Message = "Your email was confirmed before. Please login to your account",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Email already confirmed");
        }

        try
        {
            // Decode the token and attempt to confirm the email
            var decodedTokenBytes = WebEncoders.Base64UrlDecode(request.Token);
            var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);
            var result = await userManager.ConfirmEmailAsync(user, decodedToken);

            if (result.Succeeded)
            {
                return Success<string>("Email confirmed", "Your email address is confirmed. You can login now");
            }
            else
            {
                var errors = new List<Error>
                {
                    new Error
                    {
                        Code = "InvalidToken",
                        Message = "Invalid token. Please try again",
                        Field = "Token"
                    }
                };
                return BadRequest<string>(errors, "Invalid token");
            }
        }
        catch (Exception)
        {
            var errors = new List<Error>
            {
                new()
                {
                    Code = "TokenDecodingError",
                    Message = "Invalid token. Please try again",
                    Field = "Token"
                }
            };
            return BadRequest<string>(errors, "Token error");
        }
    }

    public async Task<Response<string>> Handle(ResendConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        // Validate the email provided
        if (string.IsNullOrEmpty(request.Email))
        {
            var errors = new List<Error>
            {
                new()
                {
                    Code = "InvalidEmail",
                    Message = "Invalid email",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Invalid email");
        }

        // Check if the email is registered
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            var errors = new List<Error>
            {
                new()
                {
                    Code = "EmailNotRegistered",
                    Message = "This email address has not been registered yet",
                    Field = "Email"
                }
            };
            return NotFound<string>(errors, "Email not registered");
        }

        // Check if the email is already confirmed
        if (user.EmailConfirmed)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "EmailAlreadyConfirmed",
                    Message = "Your email address was confirmed before. Please login to your account",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Email already confirmed");
        }

        try
        {
            // Attempt to send the confirmation email
            if (await emailService.SendConfirmEMailAsync(user))
            {
                return Success<string>("Confirmation link sent", "Please confirm your email address");
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
        catch (Exception)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "EmailSendingException",
                    Message = "Failed to send email. Please contact admin",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Email sending error");
        }
    }
}