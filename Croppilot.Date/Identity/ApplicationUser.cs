using Croppilot.Date.Models;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Date.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Address { get; set; }
		public string? Phone { get; set; } = null!;
		public string? OTPCode { get; set; } = null;
		public List<RefreshToken>? RefreshTokens { get; set; }
		public string? Provider { get; set; }
		public Wishlist? Wishlist { get; set; }
	}
}
