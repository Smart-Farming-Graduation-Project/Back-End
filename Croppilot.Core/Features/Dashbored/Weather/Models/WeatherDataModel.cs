using Croppilot.Core.Features.Dashbored.Weather.Results;

namespace Croppilot.Core.Features.Dashbored.Weather.Models
{
    public class WeatherDataModel(string city) : IRequest<Response<WeatherDataResult>>
    {
        public string? City { get; set; } = city;

    }

}