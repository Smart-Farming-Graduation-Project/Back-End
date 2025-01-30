using AutoMapper;
using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Queries.Models;
using Croppilot.Core.Featuers.Authentication.Queries.Result;
using Croppilot.Date.Identity;
using Croppilot.Services.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Core.Featuers.Authentication.Queries.Handlers
{
	internal class GetUserByUserNameQueryHandler : ResponseHandler, IRequestHandler<GetUserByUserNameQuery, Response<GetUser>>
	{
		private readonly IMapper _mapper;
		private readonly IAuthenticationService _service;
		public GetUserByUserNameQueryHandler(UserManager<ApplicationUser> userManager, IAuthenticationService service, IMapper mapper)
		{
			_mapper = mapper;
			_service = service;
		}
		public async Task<Response<GetUser>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
		{
			var userQuery = await _service.GetUserByUserName(request.UserName);
			if (userQuery is null)
				return NotFound<GetUser>("User do not exist");
			return Success(_mapper.Map<GetUser>(userQuery));
		}
	}
}
