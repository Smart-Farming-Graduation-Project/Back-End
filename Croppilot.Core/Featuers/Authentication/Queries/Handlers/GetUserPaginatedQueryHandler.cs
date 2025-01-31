using AutoMapper;
using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Queries.Models;
using Croppilot.Core.Featuers.Authentication.Queries.Result;
using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Comman;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Core.Featuers.Authentication.Queries.Handlers
{
	internal class GetUserPaginatedQueryHandler : ResponseHandler, IRequestHandler<GetUserPaginatedQuery, PaginatedResult<GetUser>>
	{
		private readonly IMapper _mapper;
		private readonly UserManager<ApplicationUser> _userManager;
		public GetUserPaginatedQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
		{
			_mapper = mapper;
			_userManager = userManager;
		}
		public async Task<PaginatedResult<GetUser>> Handle(GetUserPaginatedQuery request, CancellationToken cancellationToken)
		{
			var response = await _userManager.Users
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
