using Croppilot.Core.Features.Authorization.Bases;
using Croppilot.Core.Features.Authorization.Commands.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authorization.Commands.Handlers
{
	internal class DeleteRoleCommandHandler : AuthorizationHandlerBase, IRequestHandler<DeleteRoleCommand, Response<string>>
	{
		public DeleteRoleCommandHandler(IAuthorizationService service) : base(service) { }
		public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
		{
			var role = await _service.GetRoleByNameAsync(request.RoleName);
			if (role is null) return NotFound<string>("This role does not exist");
			if (!await _service.IsRoleFree(request.RoleName)) return BadRequest<string>("Role is not free so cannot delete");
			var result = await _service.DeleteRoleAsync(role);
			return result.Succeeded ? Deleted<string>() : BadRequest<string>(result.Errors.FirstOrDefault().Description);
		}
	}
}
