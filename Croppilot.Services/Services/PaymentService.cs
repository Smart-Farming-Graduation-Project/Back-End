using Croppilot.Date.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using System.Security.Claims;

namespace Croppilot.Services.Services
{
	public class PaymentService : IPaymentService
	{
		private readonly StripeSettings _stripeSettings;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public PaymentService(IOptions<StripeSettings> stripeOptions, IHttpContextAccessor httpContextAccessor)
		{
			_stripeSettings = stripeOptions.Value;
			StripeConfiguration.ApiKey = _stripeSettings.Secretkey;
			_httpContextAccessor = httpContextAccessor;
		}

		public string CreateCheckoutSession(int orderId, decimal totalAmount, string? successUrl, string? cancelUrl)
		{
			var options = new SessionCreateOptions()
			{
				LineItems = new()
				{
					new SessionLineItemOptions()
					{
						PriceData = new SessionLineItemPriceDataOptions()
						{
							Currency = "EGP",
							UnitAmount = (long)(totalAmount * 100),
							ProductData = new SessionLineItemPriceDataProductDataOptions()
							{
								Name = "Payment Order"
							}
						},
						Quantity = 1
					}
				},
				Metadata = new()
				{
					{ "OrderId", orderId.ToString() }
				},
				CustomerEmail = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value,
				Mode = "payment",
				SuccessUrl = successUrl,
				CancelUrl = cancelUrl

			};
			var service = new SessionService();
			var session = service.Create(options);
			return session.Url;
		}
	}
}
