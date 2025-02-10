using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    public class ForgetPasswordHandlers(UserManager<ApplicationUser> userManager, IEmailService emailService) : ResponseHandler,
        IRequestHandler<ForgetPasswordCommand, Response<string>>,
        IRequestHandler<ResetPasswordCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Email)) return BadRequest<string>("Invalid email");

            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null) return BadRequest<string>("This email address has not been registered yet");
            if (user.EmailConfirmed == false) return BadRequest<string>("Please confirm your email address first.");

            try
            {
                if (await emailService.SendForgotUsernameOrPasswordEmail(user))
                {
                    return Success("Forgot username or password email sent", "Please check your email");
                }

                return BadRequest<string>("Failed to send email. Please contact admin");
            }
            catch (Exception)
            {
                return BadRequest<string>("Failed to send email. Please contact admin");
            }
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user == null) return BadRequest<string>("This email address has not been registerd yet");
            if (user.EmailConfirmed == false) return BadRequest<string>("PLease confirm your email address first");

            try
            {
                var decodedTokenBytes = WebEncoders.Base64UrlDecode(request.Token);
                var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);

                var result = await userManager.ResetPasswordAsync(user, decodedToken, request.NewPassword);
                if (result.Succeeded)
                {
                    return Success("Password reset success", "Your password has been reset");
                }

                return BadRequest<string>("Invalid token. Please try again");
            }
            catch (Exception)
            {
                return BadRequest<string>("Invalid token. Please try again");
            }
        }
    }
}
