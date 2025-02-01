using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Commands.Result;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Commands.Models
{
	public class SignInCommand : IRequest<Response<SignInResponse>>
	{
		public required string UserName { get; set; }
		public required string Password { get; set; }
		public SignInCommand(string userName, string password)
		{
			UserName = userName;
			Password = password;
		}
	}
}
