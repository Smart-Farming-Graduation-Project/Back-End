using Croppilot.Core.Bases;
using MediatR;

namespace Croppilot.Core.Features.Authentication.Commands.Models
{
	public class RevokeRefreshTokenCommand : IRequest<Response<string>>
	{
		public string RefreshToken { get; set; }
		public RevokeRefreshTokenCommand(string refreshToken)
		{
			RefreshToken = refreshToken;
		}
	}
}
