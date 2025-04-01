using Croppilot.Core.Features.Dashbored.Weather.Results;

namespace Croppilot.Core.Features.Dashbored.Weather.Models
{
    public class WeatherForcastModel(string city) : IRequest<Response<IEnumerable<WeatherForcastResult>>>
    {
        public string City { get; set; } = city;
    }
}
