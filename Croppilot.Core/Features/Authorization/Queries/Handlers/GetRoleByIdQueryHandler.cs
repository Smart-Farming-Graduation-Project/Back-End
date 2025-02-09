using Croppilot.Core.Features.Authorization.Bases;
using Croppilot.Core.Features.Authorization.Queries.Models;
using Croppilot.Core.Features.Authorization.Queries.Result;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authorization.Queries.Handlers
{
    internal class GetRoleByIdQueryHandler : AuthorizationHandlerBase, IRequestHandler<GetRoleByIdQuery, Response<GetRole>>
	{
		public GetRoleByIdQueryHandler(IAuthorizationService service) : base(service) { }

		public async Task<Response<GetRole>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
		{
			var role = await _service.GetRoleByIdAsync(request.Id);
			if (role is null) return NotFound<GetRole>("This role does not exist");
			return Success(role.Adapt<GetRole>());
		}
	}
}
