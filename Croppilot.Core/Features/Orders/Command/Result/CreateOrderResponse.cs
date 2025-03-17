namespace Croppilot.Core.Features.Orders.Command.Result
{
	public class CreateOrderResponse
	{
		public int OrderId { get; set; }
		public decimal TotalAmount { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public List<string> PaymentMethods { get; } = new() { "Credit Card" };
	}
}
