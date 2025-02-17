using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class RegisterWithExternalHandlers(
    IExternalAuthService externalAuth,
    IUserService userService,
    IAuthenticationService authenticationService,
    IAuthorizationService authorizationService)
    : ResponseHandler, IRequestHandler<RegisterWithExternalCommand, Response<string>>
{
    public async Task<Response<string>> Handle(RegisterWithExternalCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            // Step 1: Validate external token and retrieve user info
            var externalUser = request.Provider switch
            {
                SD.Facebook => await externalAuth.VerifyFacebookToken(request.AccessToken),
                SD.Google => await externalAuth.VerifyGoogleTokenAsync(request.AccessToken),
                _ => throw new ArgumentException("Invalid provider")
            };
            if (externalUser == null)
            {
                return Unauthorized<string>($"Unable to authenticate with {request.Provider}");
            }
            // Step 2: Check if the user already exists
            var existingUser = await userService.GetUserByEmail(externalUser.Email);
            if (existingUser is not null)
            {
                return BadRequest<string>($"{externalUser.Name} Is Already Exit");
            }
            var userToAdd = new ApplicationUser()
            {
                FirstName = request.FirstName.ToLower(),
                LastName = request.LastName.ToLower(),
                UserName = request.FirstName + request.LastName,
                Provider = request.Provider,
                Email = existingUser.Email,
                EmailConfirmed = true
            };
            var result = await externalAuth.CreateUser(userToAdd);
            if (!result.Succeeded)
            {
                return BadRequest<string>(result.Errors.FirstOrDefault()?.Description);
            }

            // Assign role
            await authorizationService.AssignRolesToUser(userToAdd, [SD.UserRole]);

            return Created("User Added successfully", "Your account has been created");
        }
        catch (Exception ex)
        {
            return InternalError<string>($"An error occurred: {ex.Message}");

        }
    }
}