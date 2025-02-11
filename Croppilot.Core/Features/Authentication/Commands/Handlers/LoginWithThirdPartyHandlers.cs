using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Commands.Result;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    public class LoginWithThirdPartyHandlers(IAuthenticationService service,
        IExternalAuthService externalAuth, IUserService userService)
        : ResponseHandler, IRequestHandler<LoginWithExternalCommand, Response<SignInResponse>>
    {
        public async Task<Response<SignInResponse>> Handle(LoginWithExternalCommand request,
            CancellationToken cancellationToken)
        {
            var externalUser = request.Provider switch
            {
                SD.Facebook => await externalAuth.VerifyFacebookToken(request.AccessToken),
                SD.Google => await externalAuth.VerifyGoogleTokenAsync(request.AccessToken),
                _ => throw new ArgumentException("Invalid provider")
            };

            if (externalUser == null)
            {
                return Unauthorized<SignInResponse>($"Unable to login with {request.Provider.ToLower()}");
            }
            ApplicationUser user = await userService.GetUserByEmail(externalUser.Email)
                                   ?? await userService.GetUserByUserName(externalUser.Name);

            if (user is null)
                return BadRequest<SignInResponse>("No account found in database. Please register.");


            var tokens = await service.GetJWTtoken(user);


            return Success(new SignInResponse
            {
                UserName = user.UserName,
                IsAuthenticated = true,
                Tokens = tokens
            });
        }


    }
}
