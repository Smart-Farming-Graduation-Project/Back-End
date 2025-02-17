using Croppilot.Core.Features.Authentication.Commands.Models;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    public class ChangeUserPasswordCommandHandler(IAuthenticationService service, IUserService userService)
        : ResponseHandler, IRequestHandler<ChangeUserPasswordCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request,
            CancellationToken cancellationToken)
        {
            var user = await userService.GetUserById(request.Id);
            if (user is null) return NotFound<string>("User does not exist");
            var result = await service.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (result.Succeeded) return Success(string.Empty);
            return BadRequest<string>(string.Join("; ", result.Errors.Select(e => e.Description)));

        }
    }
}