namespace Croppilot.Core.Features.User.Commands.Models
{
	public class ChangeUserImageCommand : IRequest<Response<string>>
	{
		public required IFormFile Image { get; set; }
	}
}
