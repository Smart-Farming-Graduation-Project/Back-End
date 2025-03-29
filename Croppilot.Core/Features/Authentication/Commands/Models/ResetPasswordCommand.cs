using System.ComponentModel.DataAnnotations;

namespace Croppilot.Core.Features.Authentication.Commands.Models
{
    public class ResetPasswordCommand : IRequest<Response<string>>
    {
        [Required]
        public string Token { get; set; }
        [Required]
        //[RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required,
         StringLength(15, MinimumLength = 6,
             ErrorMessage = "New Password must be at least {2}, and maximum {1} characters")]
        public string NewPassword { get; set; }
        [Compare(nameof(NewPassword), ErrorMessage = "ConfirmPassword must match new password")]
        public string ConfirmPassword { get; set; }

    }
}
