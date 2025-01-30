using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Commands.Models;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Commands.Handlers
{
	internal class SignInCommandHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<string>>
	{
		private readonly IAuthenticationService _service;
		public SignInCommandHandler(IAuthenticationService service)
		{
			_service = service;
		}
		public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
		{
			var user = await _service.GetUserByUserName(request.UserName);
			if (user is null) return BadRequest<string>("Username or Password are wrong");
			if (await _service.CheckPasswordAsync(user, request.Password) == false) return BadRequest<string>("Username or Password are wrong");
			var token = await _service.GetJWTtoken(user);
			return Success(token);
		}
	}
}
