using AutoMapper;
using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Commands.Models;
using Croppilot.Date.Identity;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Commands.Handlers
{
	internal class AddUserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
	{
		private readonly IMapper _mapper;
		private readonly IAuthenticationService _service;

		public AddUserCommandHandler(IAuthenticationService service, IMapper mapper)
		{
			_mapper = mapper;
			_service = service;
		}
		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			if (await _service.GetUserByEmail(request.Email) is not null)
				return BadRequest<string>("Email must be unique");
			if (await _service.GetUserByUserName(request.UserName) is not null)
				return BadRequest<string>("UserName must be unique");
			var user = _mapper.Map<ApplicationUser>(request);
			var result = await _service.CreateUserAsync(user, request.Password);

			if (result.Succeeded)
				return Created(string.Empty, "User Added successfully");
			return BadRequest<string>(result.Errors.FirstOrDefault().Description);
		}
	}
}
