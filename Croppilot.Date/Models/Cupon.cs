using Croppilot.Date.Enum;

namespace Croppilot.Date.Models
{
	public class Cupon
	{
		public Cupon()
		{
			Products = new List<Product>();
		}
		public int Id { get; set; }
		public required string Code { get; set; }
		public Discount_Type Discount_Type { get; set; }
		public decimal Discount_Value { get; set; }
		public DateTime ExpirationDate { get; set; }
		public bool IsDeleted { get; set; } = false;
		public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
		public DateTime? UpdatedDate { get; set; } = null;
		public int UsageLimit { get; set; }
		public int UsageCount { get; set; }
		public bool IsActive =>
			DateTime.UtcNow < ExpirationDate
			&& !IsDeleted
			&& UsageCount < UsageLimit;
		public ICollection<Product>? Products { get; set; }
		public required string UserId { get; set; }
		public ApplicationUser User { get; set; }
	}
}
