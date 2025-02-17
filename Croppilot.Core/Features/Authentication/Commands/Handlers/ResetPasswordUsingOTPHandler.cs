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
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
            return BadRequest<string>("This email address has not been registered yet");
        if (!user.EmailConfirmed)
            return BadRequest<string>("Please confirm your email address first.");
        try
        {
            var sendCodeResult = await emailService.SendCodeResetPassword(request.Email);

            if (sendCodeResult == "Success")
            {
                return Success("Reset code sent", "Please check your email for the OTP code.");
            }

            return BadRequest<string>("Failed to send email. Please try again later.");
        }
        catch (Exception ex)
        {
            return BadRequest<string>($"An unexpected error occurred: {ex.Message}");
        }

    }

    public Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}