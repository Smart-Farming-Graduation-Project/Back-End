using Croppilot.Date.Enum;

namespace Croppilot.Date.Models;

public class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public string ShippingAddress { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus Status { get; set; }

    public decimal TotalAmount { get; set; }
    
    public ICollection<OrderItem> OrderItems { get; set; }
}