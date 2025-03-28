using Croppilot.Core.Features.Dashbored.Weather.Models;
using Croppilot.Core.Features.Dashbored.Weather.Results;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Core.Features.Dashbored.Weather.Handlers
{
    public class WeatherHandlers(IWeatherServices weatherServices) : ResponseHandler,
      IRequestHandler<WeatherForcastModel, Response<IEnumerable<WeatherForcastResult>>>,
        IRequestHandler<WeatherDataModel, Response<WeatherDataResult>>
    {
        public async Task<Response<IEnumerable<WeatherForcastResult>>> Handle(WeatherForcastModel request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await weatherServices.GetWeatherForecastAsync(request.City);
                var weatherForcastResult = response.Adapt<IEnumerable<WeatherForcastResult>>();
                var result = Success(weatherForcastResult, "Weather forecast fetched successfully!");
                result.Meta = new Dictionary<string, object> { { "count", weatherForcastResult.Count() } };
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest<IEnumerable<WeatherForcastResult>>(ex.Message);
            }
        }

        public async Task<Response<WeatherDataResult>> Handle(WeatherDataModel request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await weatherServices.GetWeatherDataAsync(request.City);
                var result = response.Adapt<WeatherDataResult>();
                return Success(result, "Weather data fetched successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest<WeatherDataResult>(ex.Message);
            }
        }
    }
}
