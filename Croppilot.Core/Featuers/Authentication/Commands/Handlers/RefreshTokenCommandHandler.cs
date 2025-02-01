using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Commands.Models;
using Croppilot.Core.Featuers.Authentication.Commands.Result;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Commands.Handlers
{
	internal class RefreshTokenCommandHandler : ResponseHandler, IRequestHandler<RefreshTokenCommand, Response<SignInResponse>>
	{
		private readonly IAuthenticationService _service;
		public RefreshTokenCommandHandler(IAuthenticationService service)
		{
			_service = service;
		}
		public async Task<Response<SignInResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
		{
			var user = await _service.GetUserByUserName(request.UserName);
			if (user is null) return BadRequest<SignInResponse>("Invalid User");
			var tokenResponse = await _service.RefreshTokenAsync(user, request.RefreshToken);
			if (tokenResponse.RefreshToken == request.RefreshToken) return BadRequest<SignInResponse>("Invalid Token");
			var response = new SignInResponse()
			{
				UserName = request.UserName,
				IsAuthenticated = true,
				Tokens = tokenResponse
			};
			return Success(response);
		}
	}
}
