using Croppilot.Core.Features.User.Queries.Models;
using Croppilot.Core.Features.User.Queries.Result;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.User.Queries.Handlers
{
	internal class GetUserRolesQueryHandler : ResponseHandler, IRequestHandler<GetUserRolesQuery, Response<GetUserRoleResult>>
	{
		private readonly IUserService _service;
		public GetUserRolesQueryHandler(IUserService service)
		{
			_service = service;
		}
		public async Task<Response<GetUserRoleResult>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
		{
			var user = await _service.GetUserByUserName(request.UserName);
			if (user is null) return NotFound<GetUserRoleResult>("this user does not exist");
			return Success(new GetUserRoleResult()
			{
				UserName = request.UserName,
				Roles = await _service.GetUserRolesAsync(user)
			});
		}
	}
}
