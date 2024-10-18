namespace Croppilot.Date.Models;
public class ProductImage
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Image URL is required")]
    public string ImageUrl { get; set; }

    [Required(ErrorMessage = "Product ID is required")]
    public int ProductId { get; set; }

    public Product Product { get; set; }
}