using Croppilot.Core.Features.CosmosDb.Models;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting(RateLimiters.IoTEndpointsLimit)]
    public class IoTController(IMediator mediator) : AppControllerBase
    {
        [HttpGet("latest-reading")]
        public async Task<IActionResult> GetLatestIoTData()
        {
            var response = await mediator.Send(new GetIoTData());
            return NewResult(response);

        }
        [HttpGet("GetIotData/{id}/{partitionKey}")]
        public async Task<IActionResult> GetIoTData(string id, string partitionKey)
        {
            var response = await mediator.Send(new ReadingRequest(id, partitionKey));
            return NewResult(response);


        }
        [HttpGet("Get-All-Data")]
        public async Task<IActionResult> GetIoTData()
        {
            var response = await mediator.Send(new AllReadingRequest());
            return NewResult(response);


        }
        [HttpGet("GetIotDataByDeviceKey/{partitionKey}")]
        public async Task<IActionResult> GetIoTData(string partitionKey)
        {
            var response = await mediator.Send(new GetReadingByDevice(partitionKey));
            return NewResult(response);


        }
    }
}
