﻿using System.ComponentModel.DataAnnotations;

namespace Croppilot.Core.Features.Authentication.Commands.Models
{
    public class RegisterWithExternalCommand : IRequest<Response<string>>
    {
        [Required,
         StringLength(15, MinimumLength = 3,
             ErrorMessage = "First name must be at least {2}, and maximum {1} characters")]
        public string FirstName { get; set; }

        [Required,
         StringLength(15, MinimumLength = 3,
             ErrorMessage = "Last name must be at least {2}, and maximum {1} characters")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }
        public string? Address { get; set; }
        [Required]
        public string AccessToken { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Provider { get; set; }
        public string profileImage { get; set; }

    }
}

