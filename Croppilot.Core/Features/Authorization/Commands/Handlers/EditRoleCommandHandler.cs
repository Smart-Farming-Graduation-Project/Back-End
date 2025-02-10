using Croppilot.Core.Features.Authorization.Bases;
using Croppilot.Core.Features.Authorization.Commands.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authorization.Commands.Handlers
{
	internal class EditRoleCommandHandler : AuthorizationHandlerBase, IRequestHandler<EditRoleCommand, Response<string>>
	{

		public EditRoleCommandHandler(IAuthorizationService service) : base(service) { }
		public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
		{
			var role = await _service.GetRoleByNameAsync(request.CurrentName);
			if (role is null)
				return NotFound<string>("This role does not exist");
			if (await _service.IsRoleExistAsync(request.NewName)) return BadRequest<string>("This role already exist");
			var result = await _service.EditRoleAsync(role, request.NewName);
			return result.Succeeded ? Success(string.Empty) : BadRequest<string>(result.Errors.FirstOrDefault().Description);

		}
	}
}
