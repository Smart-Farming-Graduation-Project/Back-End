using Croppilot.Core.Features.Authentication.Commands.Models;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    internal class ChangeUserPasswordCommandHandler(IAuthenticationService service, IUserService userService)
        : ResponseHandler, IRequestHandler<ChangeUserPasswordCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request,
            CancellationToken cancellationToken)
        {
            // Retrieve the user by Id
            var user = await userService.GetUserById(request.Id);
            if (user is null)
            {
                var errors = new List<Error>
                {
                    new Error
                    {
                        Code = "UserNotFound",
                        Message = "User does not exist",
                        Field = "Id"
                    }
                };

                return NotFound<string>(errors, "User not found");
            }

            // Attempt to change the user's password
            var result = await service.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (result.Succeeded)
                return Success(string.Empty);

            else
            {
                // Extract the first error description from IdentityResult
                var errorDescription = result.Errors.FirstOrDefault()?.Description ?? "Password change failed";
                var errors = new List<Error>
                {
                    new Error
                    {
                        Code = "PasswordChangeError",
                        Message = errorDescription,
                        Field = "Password"
                    }
                };
                return BadRequest<string>(errors, "Password change error");
            }
        }
    }
}