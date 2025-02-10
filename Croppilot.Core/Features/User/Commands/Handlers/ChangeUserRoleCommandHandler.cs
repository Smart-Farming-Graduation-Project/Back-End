using Croppilot.Core.Features.User.Commands.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.User.Commands.Handlers
{
	internal class ChangeUserRoleCommandHandler : ResponseHandler, IRequestHandler<ChangeUserRoleCommand, Response<string>>
	{
		private readonly IUserService _Service;
		private readonly IAuthorizationService _authorizationService;
		public ChangeUserRoleCommandHandler(IUserService Service, IAuthorizationService AuthorizationService)
		{
			_Service = Service;
			_authorizationService = AuthorizationService;
		}
		public async Task<Response<string>> Handle(ChangeUserRoleCommand request, CancellationToken cancellationToken)
		{
			var user = await _Service.GetUserByUserName(request.UserName);
			if (user is null) return NotFound<string>("this user does not exist");
			if (!await _authorizationService.IsRoleExistAsync(request.RoleName)) return NotFound<string>($"{request.RoleName} role does not exist");
			if (!await _authorizationService.IsRoleExistAsync(request.NewRoleName)) return NotFound<string>($"{request.NewRoleName} role does not exist");
			if (!await _Service.IsUserAssignedToRole(user, request.RoleName)) return BadRequest<string>($"user is not assigned to {request.RoleName} role");
			if (await _Service.IsUserAssignedToRole(user, request.NewRoleName)) return BadRequest<string>($"user already assigned to {request.NewRoleName} role");
			var result = await _Service.ChangeUserRole(user, request.RoleName, request.NewRoleName);
			return result.Succeeded ?
				Success($"user role {request.RoleName} is changed to {request.NewRoleName}")
				: BadRequest<string>(result.Errors.First().Description);

		}
	}
}
