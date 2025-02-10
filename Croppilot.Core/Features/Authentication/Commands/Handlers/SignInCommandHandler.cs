using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Core.Features.Authentication.Commands.Result;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Authentication.Commands.Handlers
{
	internal class SignInCommandHandler(IAuthenticationService service, IUserService _userService)
		: ResponseHandler, IRequestHandler<SignInCommand, Response<SignInResponse>>
	{
		public async Task<Response<SignInResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
		{
			var user = await _userService.GetUserByUserName(request.UserName);
			if (user is null || await service.CheckPasswordAsync(user, request.Password) == false)
				return BadRequest<SignInResponse>("Username or Password are wrong");
			var tokens = await service.GetJWTtoken(user);
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
