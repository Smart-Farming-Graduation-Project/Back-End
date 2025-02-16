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
                var errors = new List<Error>
                {
                    new Error
                    {
                        Code = "ExternalAuthenticationFailed",
                        Message = $"Unable to authenticate with {request.Provider}",
                        Field = "AccessToken"
                    }
                };
                return Unauthorized<string>(errors, $"Unable to authenticate with {request.Provider}");
            }

            // Step 2: Check if the user already exists using the external email
            var existingUser = await userService.GetUserByEmail(externalUser.Email);
            if (existingUser is not null)
            {
                var errors = new List<Error>
                {
                    new Error
                    {
                        Code = "UserAlreadyExists",
                        Message = $"{externalUser.Name} already exists",
                        Field = "Email"
                    }
                };
                return BadRequest<string>(errors, "User already exists");
            }

            // Step 3: Create a new ApplicationUser using external user info and request data
            var userToAdd = new ApplicationUser()
            {
                FirstName = request.FirstName.ToLower(),
                LastName = request.LastName.ToLower(),
                UserName = $"{request.FirstName}{request.LastName}",
                Provider = request.Provider,
                Email = externalUser.Email, // Use email from external provider
                EmailConfirmed = true
            };

            // Attempt to create the user using the external auth service
            var result = await externalAuth.CreateUser(userToAdd);
            if (!result.Succeeded)
            {
                var errorDescription = result.Errors.FirstOrDefault()?.Description ?? "User creation failed";
                var errors = new List<Error>
                {
                    new Error
                    {
                        Code = "UserCreationError",
                        Message = errorDescription,
                        Field = "User"
                    }
                };
                return BadRequest<string>(errors, "User creation error");
            }

            // Step 4: Assign default user role to the new user
            await authorizationService.AssignRolesToUser(userToAdd, [SD.UserRole]);

            return Created("User Added successfully", "Your account has been created");
        }
        catch (Exception ex)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Code = "InternalError",
                    Message = $"An error occurred: {ex.Message}",
                    Field = "Server"
                }
            };
            return InternalError<string>(errors, "An error occurred");
        }
    }
}