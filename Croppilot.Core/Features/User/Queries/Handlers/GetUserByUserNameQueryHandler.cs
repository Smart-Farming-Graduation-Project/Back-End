using Croppilot.Core.Features.User.Queries.Models;
using Croppilot.Core.Features.User.Queries.Result;
using Croppilot.Date.Identity;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Core.Features.User.Queries.Handlers
{
	internal class GetUserByUserNameQueryHandler : ResponseHandler,
		IRequestHandler<GetUserByUserNameQuery, Response<GetUser>>
	{
		private readonly IUserService _service;

		public GetUserByUserNameQueryHandler(UserManager<ApplicationUser> userManager, IUserService service)
		{
			_service = service;
		}

		public async Task<Response<GetUser>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
		{
			var userQuery = await _service.GetUserByUserName(request.UserName);
			if (userQuery is null)
				return NotFound<GetUser>("User do not exist");

			var user = userQuery.Adapt<GetUser>();
			return Success(user);
		}
	}
}