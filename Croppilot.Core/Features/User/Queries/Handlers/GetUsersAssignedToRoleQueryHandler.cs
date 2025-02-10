using Croppilot.Core.Features.User.Queries.Models;
using Croppilot.Core.Features.User.Queries.Result;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.User.Queries.Handlers
{
	internal class GetUsersAssignedToRoleQueryHandler : ResponseHandler, IRequestHandler<GetUsersAssignedToRoleQuery, Response<List<GetUserAssignedToRoleResponse>>>
	{
		private readonly IUserService _Service;
		private readonly IAuthorizationService _authorizationService;
		public GetUsersAssignedToRoleQueryHandler(IUserService service, IAuthorizationService authorizationService)
		{
			_Service = service;
			_authorizationService = authorizationService;
		}
		public async Task<Response<List<GetUserAssignedToRoleResponse>>> Handle(GetUsersAssignedToRoleQuery request, CancellationToken cancellationToken)
		{
			if (!await _authorizationService.IsRoleExistAsync(request.RoleName))
				return NotFound<List<GetUserAssignedToRoleResponse>>("this role does not exist");
			var result = await _Service.GetUsersAssignedToRole(request.RoleName);
			return Success(result.Adapt<List<GetUserAssignedToRoleResponse>>());
		}
	}
}
