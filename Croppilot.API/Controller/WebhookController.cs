using Croppilot.Date.Helpers;
using Croppilot.Services.Abstract;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace Croppilot.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class WebhookController(IOrderService orderService, IOptions<StripeSettings> options) : ControllerBase
	{
		[HttpPost("StripeWebhook")]
		public async Task<IActionResult> StripeWebhook()
		{
			var stripeSettings = options.Value;
			var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
			string endpointSecret = stripeSettings.WebhookSecret;
			try
			{
				var stripeEvent = EventUtility.ParseEvent(json);
				var signatureHeader = Request.Headers["Stripe-Signature"];

				stripeEvent = EventUtility.ConstructEvent(json,
						signatureHeader, endpointSecret);
				Session? session;
				int orderId;
				if (stripeEvent.Type == EventTypes.CheckoutSessionCompleted)
				{
					session = stripeEvent.Data.Object as Session;
					if (int.TryParse(session?.Metadata["OrderId"], out orderId))
					{
						return BadRequest();
					}
					// Update order status
					await orderService.UpdateOrderStatus(orderId, OrderStatus.Confirmed);

				}
				else if (stripeEvent.Type == EventTypes.CheckoutSessionExpired)
				{
					session = stripeEvent.Data.Object as Session;
					if (int.TryParse(session?.Metadata["OrderId"], out orderId))
					{
						return BadRequest();
					}
					// Update order status
					await orderService.UpdateOrderStatus(orderId, OrderStatus.Canceled);
				}
				else
				{
					//todo: use logger
					Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
				}
				return Ok();
			}
			catch (StripeException e)
			{
				//todo: use logger
				Console.WriteLine("Error: {0}", e.Message);
				return BadRequest();
			}
			catch (Exception e)
			{
				return StatusCode(500);
			}
		}

	}
}
