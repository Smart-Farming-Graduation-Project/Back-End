using Croppilot.Core.Features.Authentication.Commands.Result;

namespace Croppilot.Core.Features.Authentication.Commands.Models
{
	public class SignInCommand : IRequest<Response<SignInResponse>>
	{
		public required string UserNameOrEmail { get; set; }
		public required string Password { get; set; }
		public SignInCommand(string userNameOrEmail, string password)
		{
			UserNameOrEmail = userNameOrEmail;
			Password = password;
		}
	}
}
