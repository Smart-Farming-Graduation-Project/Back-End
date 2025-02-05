using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
    internal class EditUserCommandHandler(IAuthenticationService service)
        : ResponseHandler, IRequestHandler<EditUserCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await service.GetUserById(request.Id);
            if (user is null) return NotFound<string>("user does not exist");
            user = request.Adapt(user); // This updates the existing 'user' object with the values from 'request'

            var result = await service.UpdateUserAsync(user);
            if (result.Succeeded) return Success(string.Empty);
            return BadRequest<string>(result.Errors.FirstOrDefault().Description.ToString());
        }
    }
}