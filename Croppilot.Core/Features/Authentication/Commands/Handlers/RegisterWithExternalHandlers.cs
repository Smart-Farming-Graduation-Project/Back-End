using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    public class RegisterWithExternalHandlers(
        IExternalAuthService externalAuth, IAuthorizationService authorizationService)
        : ResponseHandler, IRequestHandler<RegisterWithExternalCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(RegisterWithExternalCommand request, CancellationToken cancellationToken)
        {
            try
            {

                // Validate token based on provider
                bool isValidToken = request.Provider switch
                {
                    SD.Facebook => await externalAuth.ValidateFacebookTokenAsync(request.AccessToken, request.UserId),
                    SD.Google => await externalAuth.ValidateGoogleTokenAsync(request.AccessToken, request.UserId),
                    _ => throw new ArgumentException("Invalid provider")
                };

                if (!isValidToken)
                {
                    return Unauthorized<string>($"Unable to register with {request.Provider.ToLower()}");
                }

                // Check if user already exists
                var existingUser = await externalAuth.GetUserById(request.UserId);
                if (existingUser != null)
                {
                    return BadRequest<string>($"You already have an account. Please login with your {request.Provider}");
                }

                var userToAdd = new ApplicationUser()
                {
                    FirstName = request.FirstName.ToLower(),
                    LastName = request.LastName.ToLower(),
                    UserName = request.UserId,
                    Provider = request.Provider,
                };
                var result = await externalAuth.CreateUser(userToAdd);
                if (!result.Succeeded)
                {
                    return BadRequest<string>(result.Errors.FirstOrDefault()?.Description);
                }

                // Assign role
                await authorizationService.AssignRolesToUser(userToAdd, [SD.UserRole]);

                return Created("User Added successfully", "Your account has been created, please confirm your email address");


            }
            catch (Exception ex)
            {
                return InternalError<string>($"An error occurred: {ex.Message}");
            }
        }
    }
}
