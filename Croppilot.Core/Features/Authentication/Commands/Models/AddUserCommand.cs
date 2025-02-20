namespace Croppilot.Core.Features.Authentication.Commands.Models
{
	public class AddUserCommand : IRequest<Response<string>>
	{
		public required string UserName { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
		public required string ConfirmPassword { get; set; }
	}
}
