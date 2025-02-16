using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class ResetPasswordUsingOTPHandler(
    UserManager<ApplicationUser> userManager,
    IEmailService emailService)
    : ResponseHandler, IRequestHandler<ForgetPasswordUsingOTPCommand, Response<string>>
{
    public async Task<Response<string>> Handle(ForgetPasswordUsingOTPCommand request,
        CancellationToken cancellationToken)
    {
        // Validate the email field
        if (string.IsNullOrEmpty(request.Email))
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "InvalidEmail",
                    Message = "Invalid email address",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Invalid email");
        }

        // Retrieve the user by email
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "UserNotFound",
                    Message = "This email address has not been registered yet",
                    Field = "Email"
                }
            };
            return NotFound<string>(errors, "Email not registered");
        }

        // Ensure that the user's email is confirmed before proceeding
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

        try
        {
            // Attempt to send the OTP code for password reset
            var sendCodeResult = await emailService.SendCodeResetPassword(request.Email);
            if (sendCodeResult == "Success")
            {
                return Success("Reset code sent", "Please check your email for the OTP code.");
            }
            else
            {
                var errors = new List<Error>
                {
                    new()
                    {
                        Code = "OTPSendingError",
                        Message = "Failed to send email. Please try again later.",
                        Field = "Email"
                    }
                };
                return BadRequest<string>(errors, "Failed to send OTP code");
            }
        }
        catch (Exception ex)
        {
            var errors = new List<Error>
            {
                new()
                {
                    Code = "EmailSendingException",
                    Message = $"An unexpected error occurred: {ex.Message}",
                    Field = "Email"
                }
            };
            return BadRequest<string>(errors, "Unexpected error");
        }
    }

    public Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}