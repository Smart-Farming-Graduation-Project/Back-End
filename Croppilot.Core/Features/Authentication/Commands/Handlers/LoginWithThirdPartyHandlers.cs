using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    public class LoginWithThirdPartyHandlers(
        IExternalAuthService externalAuth)
        : ResponseHandler, IRequestHandler<LoginWithExternalCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(LoginWithExternalCommand request,
            CancellationToken cancellationToken)
        {
            bool isValidToken = request.Provider switch
            {
                SD.Facebook => await externalAuth.ValidateFacebookTokenAsync(request.AccessToken, request.UserId),
                SD.Google => await externalAuth.ValidateGoogleTokenAsync(request.AccessToken, request.UserId),
                _ => throw new ArgumentException("Invalid provider")
            };

            if (!isValidToken)
            {
                return Unauthorized<string>($"Unable to login with {request.Provider.ToLower()}");
            }

            var user = await externalAuth.GetUserByProviderAsync(request.UserId, request.Provider);
            if (user is false or null)
            {
                return Unauthorized<string>("Unable to find your account");
            }

            return Success<string>("User found", "");
        }


    }
}
