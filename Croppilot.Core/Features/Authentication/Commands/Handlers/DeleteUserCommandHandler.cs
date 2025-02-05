using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
	internal class DeleteUserCommandHandler(IAuthenticationService service)
		: ResponseHandler, IRequestHandler<DeleteUserCommand, Response<string>>
	{
		public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await service.GetUserById(request.Id);
			if (user is null) return NotFound<string>("User does not exist");
			var result = await service.DeleteUserAsync(user);
			if (result.Succeeded) return Success(string.Empty);
			return BadRequest<string>(result.Errors.FirstOrDefault().Description);
		}
	}
}
