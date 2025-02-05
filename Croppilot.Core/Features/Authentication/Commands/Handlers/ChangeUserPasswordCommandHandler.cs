using Croppilot.Core.Bases;
using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
	internal class ChangeUserPasswordCommandHandler : ResponseHandler, IRequestHandler<ChangeUserPasswordCommand, Response<string>>
	{
		private readonly IAuthenticationService _service;
		public ChangeUserPasswordCommandHandler(IAuthenticationService service)
		{
			_service = service;
		}
		public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
		{
			var user = await _service.GetUserById(request.Id);
			if (user is null) return NotFound<string>("User does not exist");
			var result = await _service.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
			if (result.Succeeded) return Success(string.Empty);
			return BadRequest<string>(result.Errors.FirstOrDefault().Description);
		}
	}
}
