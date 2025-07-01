using Croppilot.Date.Models;
using Microsoft.AspNetCore.Identity;

namespace Croppilot.Date.Identity
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Address { get; set; } = null;
		public string? Phone { get; set; } = null;
		public string? OTPCode { get; set; } = null;
		public DateTime? OTPExpiration { get; set; }
		public List<RefreshToken>? RefreshTokens { get; set; }
		public string? Provider { get; set; }
		public Wishlist? Wishlist { get; set; }
		public ICollection<Product> Products { get; set; }
		public ICollection<Cupon> Cupons { get; set; }
		[Required(ErrorMessage = "Image Url is required")]
		public string ImageUrl { get; set; } = null!;
		public ICollection<ChatHistory>? chatHistories { get; set; }
	}
}
