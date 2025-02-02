using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Commands.Models;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Commands.Handlers
{
	internal class RevokeRefreshTokenCommandHandler : ResponseHandler, IRequestHandler<RevokeRefreshTokenCommand, Response<string>>
	{
		private readonly IAuthenticationService _Service;
		public RevokeRefreshTokenCommandHandler(IAuthenticationService Service)
		{
			_Service = Service;
		}
		public async Task<Response<string>> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
		{
			var response = await _Service.RevokeRefreshTokenAsync(request.RefreshToken);
			if (!response) return BadRequest<string>("Invalid Token");
			return Success("Token Revoked Successfully");
		}
	}
}
