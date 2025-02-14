namespace Croppilot.Date.Models;

public class Wishlist
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public ICollection<WishlistItem> WishlistItems { get; set; } = new List<WishlistItem>();
    public ApplicationUser User { get; set; }
}