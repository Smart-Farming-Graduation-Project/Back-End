using Croppilot.Core.Features.User.Commands.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.User.Commands.Handlers
{
	internal class RemoveUserFromRoleCommandHandler : ResponseHandler, IRequestHandler<RemoveUserFromRoleCommand, Response<string>>
	{
		private readonly IUserService _Service;
		private readonly IAuthorizationService _authorizationService;
		public RemoveUserFromRoleCommandHandler(IUserService service, IAuthorizationService authorizationService)
		{
			_Service = service;
			_authorizationService = authorizationService;
		}
		public async Task<Response<string>> Handle(RemoveUserFromRoleCommand request, CancellationToken cancellationToken)
		{
			var user = await _Service.GetUserByUserName(request.UserName);
			if (user is null) return NotFound<string>("this user does not exist");
			if (!await _authorizationService.IsRoleExistAsync(request.RoleName)) return NotFound<string>("this role does not exist");
			var result = await _Service.RemoveUserRoleAsync(user, request.RoleName);
			return result.Succeeded ? Deleted<string>() : BadRequest<string>(result.Errors.First().Description);
		}
	}
}
