using Croppilot.Core.Features.Dashbored.Alerts.Models;
using Croppilot.Core.Features.Dashbored.Equipment.Models;
using Croppilot.Core.Features.Dashbored.FarmStatues;
using Croppilot.Core.Features.Dashbored.FarmStatus.Soil;
using Croppilot.Core.Features.Dashbored.Field.Models;
using Croppilot.Core.Features.Dashbored.Soil;
using Croppilot.Core.Features.Dashbored.Weather.Models;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboredController(IMediator mediator) : AppControllerBase
    {
        [ResponseCache(CacheProfileName = "OneDayCache"), HttpGet("Weather/current")]
        //[EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
        public async Task<IActionResult> GetCurrentWeather(string city = SD.DefaultCity)
        {
            var result = await mediator.Send(new WeatherDataModel(city));
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "FiveDayCache"), HttpGet("Weather/forecast")]
        //[EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
        public async Task<IActionResult> GetWeatherForecast(string? city = SD.DefaultCity)
        {
            var result = await mediator.Send(new WeatherForcastModel(city));
            return NewResult(result);
        }
        //[ResponseCache(CacheProfileName = "OneDayCache"), HttpGet("Soil/Report")]
        //[EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
        [HttpGet("Soil/Report")]
        public async Task<IActionResult> GetSoilData(double latitude = SD.Latitude, double longitude = SD.Longitude)
        {
            var result = await mediator.Send(new SoilModel(latitude, longitude));
            return NewResult(result);
        }
        [HttpGet("Field/{id}")]
        //[EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
        public async Task<IActionResult> GetFieldById(int id)
        {
            var result = await mediator.Send(new GetFieldById(id));
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "NoCache"), HttpGet("Fields")]
        //[EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
        public async Task<IActionResult> GetAllFields()
        {
            var result = await mediator.Send(new GetAllFieldModel());
            return NewResult(result);
        }
        [HttpPost("CreateField")]
        //[EnableRateLimiting(RateLimiters.WriteOperationsLimit)]
        public async Task<IActionResult> CreateField(CreateFieldModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [HttpPut("EditField")]
        //[EnableRateLimiting(RateLimiters.WriteOperationsLimit)]
        public async Task<IActionResult> UpdateField(UpdateFieldModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [HttpDelete("DeleteField{id}")]
        //[EnableRateLimiting(RateLimiters.WriteOperationsLimit)]
        public async Task<IActionResult> DeleteField(int id)
        {
            var result = await mediator.Send(new DeleteFieldModel(id));
            return NewResult(result);
        }

        [ResponseCache(CacheProfileName = "NoCache"), HttpGet("Equipments")]
        //[EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
        public async Task<IActionResult> GetAllEquipments()
        {
            var result = await mediator.Send(new GetAllEquipmentModel());
            return NewResult(result);
        }
        [HttpPost("CreateEquipment")]
        //[EnableRateLimiting(RateLimiters.WriteOperationsLimit)]
        public async Task<IActionResult> CreateEquipment(CreateEquipmentModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [HttpPut("EditEquipment")]
        //[EnableRateLimiting(RateLimiters.WriteOperationsLimit)]
        public async Task<IActionResult> UpdateEquipment(UpdateEquipmentModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [HttpDelete("DeleteEquipment{id}")]
        //[EnableRateLimiting(RateLimiters.WriteOperationsLimit)]
        public async Task<IActionResult> DeleteEquipment(string id)
        {
            var result = await mediator.Send(new DeleteEquipmentModel(id));
            return NewResult(result);
        }
        [HttpPatch("UpdateEquipmentStatus")]
        //[EnableRateLimiting(RateLimiters.WriteOperationsLimit)]
        public async Task<IActionResult> UpdateEquipmentStatus(UpdateEquipmentStatusModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "LongCache"), HttpGet("FarmStatus")]
        //[EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
        public async Task<IActionResult> GetFarmStatus()
        {
            var result = await mediator.Send(new GetFarmStatusModel());
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "LongCache"), HttpGet("SoilMoisture")]
        //[EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
        public async Task<IActionResult> GetSoilMoisture()
        {
            var result = await mediator.Send(new SoilMoistureModel());
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "NoCache"), HttpGet("GetAlerts")]
        public async Task<IActionResult> GetAlerts()
        {
            var result = await mediator.Send(new GetAllAlerts());
            return NewResult(result);
        }
        [HttpPost("CreateAlert")]
        public async Task<IActionResult> CreateAlert(CreateAlert command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
    }
}
