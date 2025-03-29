using Croppilot.Date.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Croppilot.Date.Models;

public class Product
{
	public int Id { get; set; }

	[StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
	public string Name { get; set; }

	[StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
	public string Description { get; set; }

	[Range(0.01, 1000000.00, ErrorMessage = "Price must be between 0.01 and 1,000,000.00")]
	public decimal Price { get; set; }

	public Availability Availability { get; set; }

	[Required(ErrorMessage = "Creation date is required")]
	[DataType(DataType.DateTime)]
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	[Required(ErrorMessage = "Update date is required")]
	[DataType(DataType.DateTime)]
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
	// todo : change to nullable update date should be null firstly when product is created and when it added it should be updated

	public int CategoryId { get; set; }

	[ForeignKey("CategoryId")]
	[ValidateNever]
	public Category Category { get; set; }

	[ValidateNever] public List<ProductImage> ProductImages { get; set; }
	[ValidateNever] public ICollection<Leasing> Leasings { get; set; } = new List<Leasing>();

	public ICollection<Review> Reviews { get; set; } = new List<Review>();
	public string UserId { get; set; }
	public ApplicationUser User { get; set; }
	public int? CuponId { get; set; }
	public Cupon Cupon { get; set; }

}