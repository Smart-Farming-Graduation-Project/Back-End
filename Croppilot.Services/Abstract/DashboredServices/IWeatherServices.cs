using Croppilot.Date.Models.DashboardModels;

namespace Croppilot.Services.Abstract.DashboredServices
{
    public interface IWeatherServices
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync(string city);
        Task<WeatherData> GetWeatherDataAsync(string city);
        Task<WeatherData> GetCurrentTempAndHim();
    }
}
