using Croppilot.Core.Features.CosmosDb.Models;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableRateLimiting(RateLimiters.IoTEndpointsLimit)]
    public class IoTController(IMediator mediator) : AppControllerBase
    {
        [HttpGet("latest-reading")]
        [SwaggerOperation(Summary = "Get Latest IoT Data", Description = "Retrieves the latest 10 IoT Reading data from the database.")]
        public async Task<IActionResult> GetLatestIoTData()
        {
            var response = await mediator.Send(new GetIoTData());
            return NewResult(response);

        }
        //[HttpGet("GetIotData/{id}/{partitionKey}")]
        //public async Task<IActionResult> GetIoTData(string id, string partitionKey)
        //{
        //    var response = await mediator.Send(new ReadingRequest(id, partitionKey));
        //    return NewResult(response);


        //}
        [HttpGet("Get-Last-Reading")]
        [SwaggerOperation(Summary = "Get Last IoT Reading", Description = "Retrieves the last IoT Reading data from the database.")]
        public async Task<IActionResult> GetLastReading()
        {
            var response = await mediator.Send(new GetLastReading());
            return NewResult(response);
        }


        [HttpGet("Get-All-Data")]
        public async Task<IActionResult> GetIoTData()
        {
            var response = await mediator.Send(new AllReadingRequest());
            return NewResult(response);

        }
        [HttpGet("GetIotDataByDeviceKey/{partitionKey}")]
        [SwaggerOperation(Summary = "Get IoT Data by Device Key", Description = "Retrieves IoT Reading data for a specific device partition key Like Esp or respery.")]
        public async Task<IActionResult> GetIoTData(string partitionKey = "ESP32 Client")
        {
            var response = await mediator.Send(new GetReadingByDevice(partitionKey));
            return NewResult(response);
        }
    }
}
