using Croppilot.Core.Features.AIModels.Models;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting(RateLimiters.AIModelRateLimit)]
    public class AIModelController(IMediator mediator) : AppControllerBase
    {
        [HttpPost("predict")]
        public async Task<IActionResult> Predict(PredictModelCommand command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }

        [ResponseCache(CacheProfileName = "NoCache"), HttpGet("feedback/{ImageId}")]
        public async Task<IActionResult> Feedback(Guid ImageId)
        {
            var result = await mediator.Send(new GetFeedback(ImageId));
            return NewResult(result);
        }

        [ResponseCache(CacheProfileName = "NoCache"), HttpPost("wateringFeedback")]
        public async Task<IActionResult> WateringFeedback(GetWateringFeedback command)
        {
            var language = Request.GetTypedHeaders().AcceptLanguage
                .FirstOrDefault()?.Value.ToString() ?? "en";
            command.language = language;
            var result = await mediator.Send(command);
            return NewResult(result);
        }

        [ResponseCache(CacheProfileName = "Default"), HttpGet("GetCurrentValue")]
        public async Task<IActionResult> GetCurrentValue()
        {
            var result = await mediator.Send(new GetCurrentValue());
            return NewResult(result);
        }
    }
}