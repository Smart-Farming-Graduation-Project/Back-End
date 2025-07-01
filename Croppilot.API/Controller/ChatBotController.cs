using Croppilot.Core.Features.ChatBot.Command.Models;
using Croppilot.Core.Features.ChatBot.Query.Models;

namespace Croppilot.API.Controller
{
	[Route("api/[controller]"), ApiController]
	// [EnableRateLimiting(RateLimiters.ChatBotEndpointsLimit)]
	public class ChatBotController(IMediator mediator) : AppControllerBase
	{
		[HttpGet("ChatHistory")]
		public async Task<IActionResult> GetAllChatHistory()
		{
			var response = await mediator.Send(new GetChatHistory());
			return NewResult(response);
		}
		[SwaggerOperation(
			Summary = "Get chat history by user ID",
			Description = "Retrieves chat history for a specific user within an optional date range and limit." +
			"default for last day and limit 10 messages")]
		[Authorize]
		[HttpGet("UserChatHistory")]
		public async Task<IActionResult> GetUserChatHistory([FromQuery] DateTime? startDate, DateTime? endDate, int? limit)
		{
			var response = await mediator.Send(new GetChatHistoryByUserId() { StartDate = startDate, EndDate = endDate, Limit = limit });
			return NewResult(response);
		}

		[HttpPost("Chat")]
		public async Task<IActionResult> GetChatResponse([FromBody] MessageRequestModel command)
		{
			var response = await mediator.Send(command);
			return NewResult(response);
		}

	}
}
