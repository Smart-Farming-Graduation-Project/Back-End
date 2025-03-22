using Croppilot.Core.Features.AIModels.Models;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIModelController(IMediator mediator) : AppControllerBase
    {

        [HttpPost("predict")]
        public async Task<IActionResult> Predict(PredictModelCommand command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [HttpGet("feedback/{ImageId}")]
        public async Task<IActionResult> Feedback(Guid ImageId)
        {
            var result = await mediator.Send(new GetFeedback(ImageId));
            return NewResult(result);
        }
    }
}
