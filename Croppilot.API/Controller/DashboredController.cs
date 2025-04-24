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
        public async Task<IActionResult> GetCurrentWeather(string city = SD.DefaultCity)
        {
            var result = await mediator.Send(new WeatherDataModel(city));
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "FiveDayCache"), HttpGet("Weather/forecast")]
        public async Task<IActionResult> GetWeatherForecast(string? city = SD.DefaultCity)
        {
            var result = await mediator.Send(new WeatherForcastModel(city));
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "OneDayCache"), HttpGet("Soil/Report")]
        public async Task<IActionResult> GetSoilData(double latitude = SD.Latitude, double longitude = SD.Longitude)
        {
            var result = await mediator.Send(new SoilModel(latitude, longitude));
            return NewResult(result);
        }
        [HttpGet("Field/{id}")]
        public async Task<IActionResult> GetFieldById(int id)
        {
            var result = await mediator.Send(new GetFieldById(id));
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "LongCache"), HttpGet("Fields")]
        public async Task<IActionResult> GetAllFields()
        {
            var result = await mediator.Send(new GetAllFieldModel());
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

        [ResponseCache(CacheProfileName = "LongCache"), HttpGet("Equipments")]
        public async Task<IActionResult> GetAllEquipments()
        {
            var result = await mediator.Send(new GetAllEquipmentModel());
            return NewResult(result);
        }
        [HttpPost("CreateEquipment")]
        public async Task<IActionResult> CreateEquipment(CreateEquipmentModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [HttpPut("EditEquipment")]
        public async Task<IActionResult> UpdateEquipment(UpdateEquipmentModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [HttpDelete("DeleteEquipment{id}")]
        public async Task<IActionResult> DeleteEquipment(string id)
        {
            var result = await mediator.Send(new DeleteEquipmentModel(id));
            return NewResult(result);
        }
        [HttpPatch("UpdateEquipmentStatus")]
        public async Task<IActionResult> UpdateEquipmentStatus(UpdateEquipmentStatusModel command)
        {
            var result = await mediator.Send(command);
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "LongCache"), HttpGet("FarmStatus")]
        public async Task<IActionResult> GetFarmStatus()
        {
            var result = await mediator.Send(new GetFarmStatusModel());
            return NewResult(result);
        }
        [ResponseCache(CacheProfileName = "LongCache"), HttpGet("SoilMoisture")]
        public async Task<IActionResult> GetSoilMoisture()
        {
            var result = await mediator.Send(new SoilMoistureModel());
            return NewResult(result);
        }

    }
}
