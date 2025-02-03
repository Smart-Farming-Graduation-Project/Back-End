using Croppilot.Date.Helpers;

namespace Croppilot.Core.Features.Authentication.Commands.Result
{
	public class SignInResponse
	{
		public string? UserName { get; set; }
		public bool IsAuthenticated { get; set; } = false;
		public TokenResponse? Tokens { get; set; }
	}
}
