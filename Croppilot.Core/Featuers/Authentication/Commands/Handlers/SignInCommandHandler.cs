using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Commands.Models;
using Croppilot.Core.Featuers.Authentication.Commands.Result;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Commands.Handlers
{
	internal class SignInCommandHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<SignInResponse>>
	{
		private readonly IAuthenticationService _service;
		public SignInCommandHandler(IAuthenticationService service)
		{
			_service = service;
		}
		public async Task<Response<SignInResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
		{
			var user = await _service.GetUserByUserName(request.UserName);
			if (user is null || await _service.CheckPasswordAsync(user, request.Password) == false)
				return BadRequest<SignInResponse>("Username or Password are wrong");
			var tokens = await _service.GetJWTtoken(user);
			var response = new SignInResponse()
			{
				UserName = request.UserName,
				IsAuthenticated = true,
				Tokens = tokens
			};
			return Success(response);
		}
	}
}
