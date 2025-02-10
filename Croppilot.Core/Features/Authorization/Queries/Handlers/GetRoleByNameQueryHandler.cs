using Croppilot.Core.Features.Authorization.Bases;
using Croppilot.Core.Features.Authorization.Queries.Models;
using Croppilot.Core.Features.Authorization.Queries.Result;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authorization.Queries.Handlers
{
    internal class GetRoleByNameQueryHandler : AuthorizationHandlerBase, IRequestHandler<GetRoleByNameQuery, Response<GetRole>>
	{
		public GetRoleByNameQueryHandler(IAuthorizationService service) : base(service) { }
		public async Task<Response<GetRole>> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
		{
			var role = await _service.GetRoleByNameAsync(request.RoleName);
			if (role is null) return NotFound<GetRole>("This role does not exist");
			return Success(role.Adapt<GetRole>());
		}
	}
}
