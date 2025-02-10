using Croppilot.Core.Features.Authorization.Bases;
using Croppilot.Core.Features.Authorization.Commands.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authorization.Commands.Handlers
{
	internal class AddRoleCommandHandler : AuthorizationHandlerBase, IRequestHandler<AddRoleCommand, Response<string>>
	{
		public AddRoleCommandHandler(IAuthorizationService service) : base(service) { }
		public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
		{
			if (await _service.IsRoleExistAsync(request.RoleName))
				return BadRequest<string>("This role already exist");
			var result = await _service.CreteRoleAsync(request.RoleName);
			return result.Succeeded ? Success("Role added successfully") : BadRequest<string>(result.Errors.FirstOrDefault().Description);
		}
	}
}
