using Croppilot.Core.Features.Authorization.Bases;
using Croppilot.Core.Features.Authorization.Commands.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authorization.Commands.Handlers
{
	internal class AssignRolesToUserCommandHandler : AuthorizationHandlerBase, IRequestHandler<AssignRolesToUserCommand, Response<string>>
	{
		private readonly IUserService _userService;
		public AssignRolesToUserCommandHandler(IAuthorizationService service, IUserService userService) : base(service)
		{
			_userService = userService;
		}
		public async Task<Response<string>> Handle(AssignRolesToUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userService.GetUserByUserName(request.UserName);
			if (user is null) return NotFound<string>("This user does not exist");
			foreach (var role in request.Roles)
			{
				if (!await _service.IsRoleExistAsync(role))
					return NotFound<string>($"there is no role with {role} name");
				if (await _userService.IsUserAssignedToRole(user, role))
					return BadRequest<string>($"this {role} role alreday assigned to this user");
			}
			var result = await _service.AssignRolesToUser(user, request.Roles);
			return result.Succeeded ? Success(string.Empty) : BadRequest<string>(result.Errors.First().Description);
		}
	}
}
