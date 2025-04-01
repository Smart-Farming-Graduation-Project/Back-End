namespace Croppilot.Services.Abstract
{
	public interface IPaymentService
	{
		string CreateCheckoutSession(int orderId, decimal totalAmount, string? successUrl, string? cancelUrl);
	}
}
