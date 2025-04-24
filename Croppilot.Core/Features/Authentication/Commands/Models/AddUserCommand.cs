namespace Croppilot.Core.Features.Authentication.Commands.Models
{
	public class AddUserCommand : IRequest<Response<string>>
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set; }
		public required string UserName { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
		public required string ConfirmPassword { get; set; }
		public required IFormFile Image { get; set; }
		public string? Phone { get; set; }
		public string? Address { get; set; }
	}
}
