using AutoMapper;
using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Queries.Models;
using Croppilot.Core.Featuers.Authentication.Queries.Result;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Queries.Handlers
{
	internal class GetUserByIdQueryHandler : ResponseHandler, IRequestHandler<GetUserByIdQuery, Response<GetUser>>
	{
		private readonly IMapper _mapper;
		private readonly IAuthenticationService _service;
		public GetUserByIdQueryHandler(IAuthenticationService service, IMapper mapper)
		{
			_mapper = mapper;
			_service = service;
		}
		public async Task<Response<GetUser>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
		{
			var userQuery = await _service.GetUserById(request.Id);
			if (userQuery is null)
				return NotFound<GetUser>("User do not exist");
			return Success(_mapper.Map<GetUser>(userQuery));
		}
	}
}
