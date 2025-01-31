using AutoMapper;
using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Commands.Models;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Commands.Handlers
{
	internal class DeleteUserCommandHandler : ResponseHandler, IRequestHandler<DeleteUserCommand, Response<string>>
	{
		private readonly IMapper _mapper;
		private readonly IAuthenticationService _service;
		public DeleteUserCommandHandler(IAuthenticationService service, IMapper mapper)
		{
			_mapper = mapper;
			_service = service;
		}
		public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _service.GetUserById(request.Id);
			if (user is null) return NotFound<string>("User does not exist");
			var result = await _service.DeleteUserAsync(user);
			if (result.Succeeded) return Success(string.Empty);
			return BadRequest<string>(result.Errors.FirstOrDefault().Description);
		}
	}
}
