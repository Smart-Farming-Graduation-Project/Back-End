using Croppilot.Date.Enum;
using Croppilot.Date.Identity;

namespace Croppilot.Date.Models;

public class Order
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public string ShippingAddress { get; set; }
    
    public OrderStatus Status { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;

    public ICollection<OrderItem> OrderItems { get; set; }
    
    public ApplicationUser User { get; set; }
}