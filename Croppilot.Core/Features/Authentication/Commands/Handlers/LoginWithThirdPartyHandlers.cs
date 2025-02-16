using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Commands.Result;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class LoginWithThirdPartyHandlers(
    IAuthenticationService service,
    IExternalAuthService externalAuth,
    IUserService userService)
    : ResponseHandler, IRequestHandler<LoginWithExternalCommand, Response<SignInResponse>>
{
    public async Task<Response<SignInResponse>> Handle(LoginWithExternalCommand request,
        CancellationToken cancellationToken)
    {
        // Validate the external token based on provider and retrieve external user info.
        var externalUser = request.Provider switch
        {
            SD.Facebook => await externalAuth.VerifyFacebookToken(request.AccessToken),
            SD.Google => await externalAuth.VerifyGoogleTokenAsync(request.AccessToken),
            _ => throw new ArgumentException("Invalid provider")
        };

        // If external user information could not be retrieved, return an Unauthorized response.
        if (externalUser == null)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "InvalidExternalUser",
                    Message = $"Unable to login with {request.Provider.ToLower()}",
                    Field = "AccessToken"
                }
            };
            return Unauthorized<SignInResponse>(errors, $"Unable to login with {request.Provider.ToLower()}");
        }

        // Try to locate the local user account by email or username.
        var user = await userService.GetUserByEmail(externalUser.Email)
                   ?? await userService.GetUserByUserName(externalUser.Name);

        // If no user account is found, return a NotFound response with field-specific error details.
        if (user is null)
        {
            var errors = new List<Error>
            {
                new()
                {
                    Code = "UserNotFound",
                    Message = "No account found in database. Please register.",
                    Field = "Email"
                }
            };
            return NotFound<SignInResponse>(errors, "User not found");
        }

        // Generate JWT tokens for the authenticated user.
        var tokens = await service.GetJWTtoken(user);
        return Success(new SignInResponse
        {
            UserName = user.UserName,
            IsAuthenticated = true,
            Tokens = tokens
        });
    }
}