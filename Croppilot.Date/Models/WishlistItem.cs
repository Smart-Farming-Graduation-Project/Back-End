namespace Croppilot.Date.Models;



public class WishlistItem
{
    public int Id { get; set; }
    public int WishlistId { get; set; }
    public int ProductId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;

    public Wishlist Wishlist { get; set; }
    public Product Product { get; set; }
}