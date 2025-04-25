using Croppilot.Core.Features.Cupon.Command.Models;

namespace Croppilot.API.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	[EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
	public class CuponController(IMediator mediator) : AppControllerBase
	{
		[HttpPost("CreateCupon")]
		public async Task<IActionResult> CreateCupon([FromBody] CreateCuponCommand command)
		{
			var response = await mediator.Send(command);
			return NewResult(response);
		}

		[HttpPost("AssignToProduct")]
		public async Task<IActionResult> AssignToProduct([FromBody] AssignToProductCommand command)
		{
			var response = await mediator.Send(command);
			return NewResult(response);
		}

	}
}
