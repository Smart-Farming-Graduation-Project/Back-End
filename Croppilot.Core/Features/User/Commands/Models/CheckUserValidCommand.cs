namespace Croppilot.Core.Features.User.Commands.Models
{
	public class CheckUserValidCommand : IRequest<Response<string>>
	{
		public required string UserName { get; set; }
		public required string Email { get; set; }
	}
}
