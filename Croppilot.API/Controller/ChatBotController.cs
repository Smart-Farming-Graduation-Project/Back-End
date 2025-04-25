using Croppilot.Core.Features.ChatBot.Command.Models;
using Croppilot.Core.Features.ChatBot.Query.Models;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]"), ApiController]
    [EnableRateLimiting(RateLimiters.ChatBotEndpointsLimit)]
    public class ChatBotController(IMediator mediator) : AppControllerBase
    {
        [HttpGet("ChatHistory")]
        public async Task<IActionResult> GetAllChatHistory()
        {
            var response = await mediator.Send(new GetChatHistory());
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
