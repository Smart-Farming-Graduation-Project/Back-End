using Croppilot.Date.Identity;

namespace Croppilot.Date.Models;

public class Cart
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public ApplicationUser User { get; set; }
}