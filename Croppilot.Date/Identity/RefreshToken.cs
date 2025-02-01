using System.ComponentModel.DataAnnotations.Schema;

namespace Croppilot.Date.Identity
{
	public class RefreshToken
	{
		[Key]
		public int Id { get; set; }
		public string Token { get; set; }
		public DateTime ExpiresOn { get; set; }
		public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
		public DateTime CreatedOn { get; set; }
		public DateTime? RevokedOn { get; set; }
		public bool IsActive => RevokedOn is null && !IsExpired;
		public ApplicationUser User { get; set; } = null!;
		[ForeignKey(nameof(User))]
		public string UserId { get; set; } = null!;
	}
}
