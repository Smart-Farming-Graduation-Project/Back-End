using System.ComponentModel.DataAnnotations;

namespace Croppilot.Core.Features.Authentication.Commands.Models
{
    public class ConfirmEmailCommand : IRequest<Response<string>>
    {
        [Required]
        public string Token { get; set; }
        [Required]
        //[RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }
}
