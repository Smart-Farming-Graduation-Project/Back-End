using System.ComponentModel.DataAnnotations;

namespace Croppilot.Core.Features.Authentication.Commands.Models
{
    public class LoginWithExternalCommand : IRequest<Response<string>>
    {
        [Required]
        public string AccessToken { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Provider { get; set; }
    }
}
