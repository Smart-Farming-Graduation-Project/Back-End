using Croppilot.Core.Features.Authorization.Bases;
using Croppilot.Core.Features.Authorization.Queries.Models;
using Croppilot.Core.Features.Authorization.Queries.Result;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authorization.Queries.Handlers
{
    internal class GetRoleListQueryHandler : AuthorizationHandlerBase, IRequestHandler<GetRolesListQuery, Response<List<GetRole>>>
	{
		public GetRoleListQueryHandler(IAuthorizationService service) : base(service) { }
		public async Task<Response<List<GetRole>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
		{
			var roles = await _service.GetRolesAsync();
			return Success(roles.Adapt<List<GetRole>>());
		}
	}
}
