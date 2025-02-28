using Croppilot.Core.Features.Authentication.Commands.Models;
using Croppilot.Date.Helpers;


namespace Croppilot.Core.Features.Authentication.Commands.Handlers;

internal class RefreshTokenCommandHandler(IAuthenticationService service, IUserService userService)
	: ResponseHandler, IRequestHandler<RefreshTokenCommand, Response<TokenResponse>>
{
	public async Task<Response<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
	{
		var tokenResponse = await service.RefreshTokenAsync(request.Tokens);
		if (tokenResponse.RefreshToken == request.Tokens.RefreshToken) return BadRequest<TokenResponse>("Invalid Token");
		return Success(tokenResponse);
	}
}