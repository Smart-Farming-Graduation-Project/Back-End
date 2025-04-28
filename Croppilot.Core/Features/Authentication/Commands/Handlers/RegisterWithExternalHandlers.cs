using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

public class RegisterWithExternalHandlers(
    IExternalAuthService externalAuth,
    IAuthorizationService authorizationService)
    : ResponseHandler, IRequestHandler<RegisterWithExternalCommand, Response<string>>
{
    public async Task<Response<string>> Handle(RegisterWithExternalCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Provider.Equals(SD.Facebook))
        {
            try
            {
                if (!externalAuth.FacebookValidatedAsync(request.AccessToken, request.UserId).GetAwaiter().GetResult())
                {
                    return Unauthorized<string>("Unable to register with facebook");
                }
            }
            catch (Exception)
            {
                return Unauthorized<string>("Unable to register with facebook");
            }
        }
        else if (request.Provider.Equals(SD.Google))
        {
            try
            {
                if (!externalAuth.GoogleValidatedAsync(request.AccessToken, request.UserId).GetAwaiter().GetResult())
                {
                    return Unauthorized<string>("Unable to register with google");
                }
            }
            catch (Exception)
            {
                return Unauthorized<string>("Unable to register with google");
            }
        }
        else
        {
            return BadRequest<string>("Invalid provider");
        }
        var user = await externalAuth.GetUserByProviderAsync(request.UserId, request.Provider);

        if (user != null) return BadRequest<string>(
            $"You have an account already. Please login with your {request.Provider}");
        var userToAdd = new ApplicationUser()
        {
            FirstName = request.FirstName.ToLower(),
            LastName = request.LastName.ToLower(),
            UserName = request.UserId,
            Provider = request.Provider,
            Email = request.Email,
            Address = request.Address,
            EmailConfirmed = true,
            ImageUrl = request.profileImage,
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

}
