using Croppilot.Date.DTOS;
using Croppilot.Date.Helpers;

namespace Croppilot.Core.Features.Authentication.Commands.Models
{
	public class RefreshTokenCommand : IRequest<Response<TokenResponse>>
	{
		public TokenDto Tokens { get; set; }
		public RefreshTokenCommand(TokenDto tokens)
		{
			Tokens = tokens;
		}
	}
}
