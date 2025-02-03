using Croppilot.Core.Bases;
using Croppilot.Core.Features.Authentication.Commands.Result;
using MediatR;

namespace Croppilot.Core.Features.Authentication.Commands.Models
{
	public class RefreshTokenCommand : IRequest<Response<SignInResponse>>
	{
		public string UserName { get; set; }
		public string RefreshToken { get; set; }
		public RefreshTokenCommand(string refreshToken, string userName)
		{
			RefreshToken = refreshToken;
			UserName = userName;
		}
	}
}
