using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Commands.Result;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class LoginWithThirdPartyHandlers(
    IAuthenticationService service,
    IExternalAuthService externalAuth)
    : ResponseHandler, IRequestHandler<LoginWithExternalCommand, Response<SignInResponse>>
{
    public async Task<Response<SignInResponse>> Handle(LoginWithExternalCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Provider.Equals(SD.Facebook))
        {
            try
            {
                if (!externalAuth.FacebookValidatedAsync(request.AccessToken, request.UserId).GetAwaiter().GetResult())
                {
                    return Unauthorized<SignInResponse>("Unable to login with facebook");
                }
            }
            catch (Exception)
            {
                return Unauthorized<SignInResponse>("Unable to login with facebook");
            }
        }
        else if (request.Provider.Equals(SD.Google))
        {
            try
            {
                if (!externalAuth.GoogleValidatedAsync(request.AccessToken, request.UserId).GetAwaiter().GetResult())
                {
                    return Unauthorized<SignInResponse>("Unable to login with google");
                }
            }
            catch (Exception)
            {
                return Unauthorized<SignInResponse>("Unable to login with google");
            }
        }
        else
        {
            return BadRequest<SignInResponse>("Invalid provider");
        }

        var user = await externalAuth.GetUserByProviderAsync(request.UserId, request.Provider);

        if (user == null) return Unauthorized<SignInResponse>("Unable to find your account");


        var lockoutMessage = await service.CheckAndHandleLockoutAsync(user);
        if (!string.IsNullOrEmpty(lockoutMessage))
        {
            return BadRequest<SignInResponse>(lockoutMessage);
        }

        //Successful login
        await service.ResetFailedAttemptsAsync(user);
        var tokens = await service.GetJWTtoken(user);
        return Success(new SignInResponse
        {
            UserName = user.UserName,
            IsAuthenticated = true,
            Tokens = tokens
        });
    }
}