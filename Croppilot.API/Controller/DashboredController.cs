using Croppilot.Core.Features.Dashbored.FarmStatus.Soil;
using Croppilot.Core.Features.Dashbored.Field.Models;
using Croppilot.Core.Features.Dashbored.Weather.Models;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboredController(IMediator mediator) : AppControllerBase
    {
        [HttpGet("Weather/current")]
        public async Task<IActionResult> GetCurrentWeather(string city = SD.DefaultCity)
        {
            var result = await mediator.Send(new WeatherDataModel(city));
            return NewResult(result);
        }
        [HttpGet("Weather/forecast")]
        public async Task<IActionResult> GetWeatherForecast(string? city = SD.DefaultCity)
        {
            var result = await mediator.Send(new WeatherForcastModel(city));
            return NewResult(result);
        }
        [HttpGet("Soil/Report")]
        public async Task<IActionResult> GetSoilData(double latitude = SD.Latitude, double longitude = SD.Longitude)
        {
            var result = await mediator.Send(new SoilModel(latitude, longitude));
            return NewResult(result);
        }

        [HttpPost("CreateField")]
        public async Task<IActionResult> CreateField(CreateFieldModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [HttpPut("EditField")]
        public async Task<IActionResult> UpdateField(UpdateFieldModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [HttpDelete("DeleteField{id}")]
        public async Task<IActionResult> DeleteField(int id)
        {
            var result = await mediator.Send(new DeleteFieldModel(id));
            return NewResult(result);
        }
        [HttpGet("Field/{id}")]
        public async Task<IActionResult> GetFieldById(int id)
        {
            var result = await mediator.Send(new GetFieldById(id));
            return NewResult(result);
        }
        [HttpGet("Fields")]
        public async Task<IActionResult> GetAllFields()
        {
            var result = await mediator.Send(new GetAllFieldModel());
            return NewResult(result);
        }

    }
}
