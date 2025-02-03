using Croppilot.Core.Features.Authentication.Queries.Models;
using Croppilot.Core.Features.Authentication.Queries.Result;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Core.Features.Authentication.Queries.Handlers
{
	internal class GetUserPaginatedQueryHandler(UserManager<ApplicationUser> userManager)
		: ResponseHandler, IRequestHandler<GetUserPaginatedQuery, PaginatedResult<GetUser>>
	{
		public async Task<PaginatedResult<GetUser>> Handle(GetUserPaginatedQuery request, CancellationToken cancellationToken)
		{
			var response = await userManager.Users
				.Select(u => new GetUser
				{
					Id = u.Id,
					FirstName = u.FirstName,
					LastName = u.LastName,
					FullName = $"{u.FirstName} {u.LastName}",
					Address = u.Address,
					Phone = u.Phone,
					UserName = u.UserName,
					Email = u.Email
				}).ToPaginatedListAsync(request.pageNumber, request.pageSize);

			response.Meta = new { count = response.Data.Count };
			return response;
		}
	}
}
