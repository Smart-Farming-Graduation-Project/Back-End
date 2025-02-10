using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    public class ConfirmEmailHandlers(UserManager<ApplicationUser> userManager) : ResponseHandler, IRequestHandler<ConfirmEmailCommand, Response<string>>
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
    }
}
