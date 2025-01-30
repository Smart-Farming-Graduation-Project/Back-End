using AutoMapper;
using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Commands.Models;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Commands.Handlers
{
	internal class EditUserCommandHandler : ResponseHandler, IRequestHandler<EditUserCommand, Response<string>>
	{
		private readonly IMapper _mapper;
		private readonly IAuthenticationService _service;
		public EditUserCommandHandler(IAuthenticationService service, IMapper mapper)
		{
			_mapper = mapper;
			_service = service;
		}
		public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _service.GetUserById(request.Id);
			if (user is null) return NotFound<string>("user does not exist");
			var newUser = _mapper.Map(request, user);
			var result = await _service.UpdateUserAsync(newUser);
			if (result.Succeeded) return Success(string.Empty);
			return BadRequest<string>(result.Errors.FirstOrDefault().Description.ToString());
		}
	}
}
