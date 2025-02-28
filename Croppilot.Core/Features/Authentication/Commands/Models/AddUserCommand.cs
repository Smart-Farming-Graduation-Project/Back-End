namespace Croppilot.Core.Features.Authentication.Commands.Models
{
    public class AddUserCommand : IRequest<Response<string>>
    {
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public string? Phone { get; set; } = null;
        public string? Address { get; set; } = null;
    }
}
