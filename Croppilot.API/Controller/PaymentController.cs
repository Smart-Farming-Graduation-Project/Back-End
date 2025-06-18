using Croppilot.Core.Features.Payment.Command.Model;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[EnableRateLimiting(RateLimiters.PaymentEndpointsLimit)]
    public class PaymentController(IMediator mediator) : AppControllerBase
    {

        [HttpPost("checkout-session")]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] CreateCheckOutSessionCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }
    }
}
