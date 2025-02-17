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
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null) return BadRequest<string>("This email address has not been registered yet");
        if (user.EmailConfirmed == true) return BadRequest<string>("Your email was confirmed before. Please login to your account");
        try
        {
            var decodedTokenBytes = WebEncoders.Base64UrlDecode(request.Token);
            var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);

            var result = await userManager.ConfirmEmailAsync(user, decodedToken);
            if (result.Succeeded)
            {
                return Success<string>("Email confirmed", "Your email address is confirmed. You can login now");
            }

            return BadRequest<string>("Invalid token. Please try again");
        }
        catch (Exception)
        {
            return BadRequest<string>("Invalid token. Please try again");



        }
    }



    public async Task<Response<string>> Handle(ResendConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Email)) return BadRequest<string>("Invalid email");
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user == null) return BadRequest<string>("This email address has not been registered yet");
        if (user.EmailConfirmed == true) return BadRequest<string>("Your email address was confirmed before. Please login to your account");
        try
        {
            if (await emailService.SendConfirmEMailAsync(user))
            {
                return Success<string>("Confirmation link sent", "Please confirm your email address");
            }

            return BadRequest<string>("Failed to send email. PLease contact admin");
        }
        catch (Exception)
        {
            return BadRequest<string>("Failed to send email. PLease contact admin");
        }
    }
}
