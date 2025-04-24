using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Comman;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract.DashboredServices;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Croppilot.Services.Services.DashboredServices
{
    public class WeatherServices(IUnitOfWork unit, IConfiguration configuration, HttpClient httpClient) : IWeatherServices
    {
        //private string test = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&units=metric&appid={apiKey}";

        private readonly string BaseUrl = SD.WeatherAPIBase;
        private readonly string apiKey = configuration["WeatherApi:ApiKey"];

        public async Task<WeatherData> GetWeatherDataAsync(string? city)
        {
            var response = await httpClient.GetStringAsync($"{BaseUrl}/weather?q={city}&appid={apiKey}&units=metric");
            var json = JObject.Parse(response);
            var weatherdData = new WeatherData
            {
                Temperature = json["main"]["temp"].Value<double>(),
                Humidity = json["main"]["humidity"].Value<double>(),
                WindSpeed = json["wind"]["speed"].Value<double>(),
                Condition = json["weather"][0]["main"].ToString(),
                Location = city,
                LastUpdated = DateTime.UtcNow,
                UvIndex = json["uvGetWeatherDatai"]?.Value<double>() ?? 0.0,
                Pressure = json["main"]["pressure"].Value<double>()
            };
            await unit.WeatherDataRepository.AddAsync(weatherdData);
            return weatherdData;
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync(string city)
        {
            var response = await httpClient.GetStringAsync($"{BaseUrl}/forecast?q={city}&units=metric&appid={apiKey}");
            var json = JObject.Parse(response);

            var forecastList = json["list"] as JArray;
            var cityInfo = json["city"];
            var dailyForecasts = forecastList
             .GroupBy(item =>
                 DateTime.Parse(item["dt_txt"].ToString()).Date)
             .Select(group => new WeatherForecast
             {
                 Date = group.Key,
                 Day = group.Key.ToString("ddd"),
                 Condition = GetMostCommonCondition(group),
                 High = Math.Round(group.Max(item => item["main"]["temp"].Value<double>()), 1),
                 Low = Math.Round(group.Min(item => item["main"]["temp"].Value<double>()), 1),
                 Precipitation = Math.Round(group.Sum(item =>
                     item["rain"]?["3h"]?.Value<double>() ??
                     item["rain"]?["1h"]?.Value<double>() ?? 0.0), 1),
                 Wind = Math.Round(group.Average(item => item["wind"]["speed"].Value<double>()), 1),
                 Humidity = (int)Math.Round(group.Average(item => item["main"]["humidity"].Value<double>())),
                 Pressure = (int)Math.Round(group.Average(item => item["main"]["pressure"].Value<double>())),
                 Icon = GetMostCommonIcon(group)
             })
             .Take(5) // Get next 5 days
             .ToList();
            await unit.WeatherForecastRepository.AddRangeAsync(dailyForecasts);

            return dailyForecasts;
        }

        public async Task<WeatherData> GetCurrentTempAndHim()
        {
            //geet last recod in db "this is for today make scence"
            return await unit.WeatherDataRepository.GetLastRecord();
        }
        private string GetMostCommonCondition(IEnumerable<JToken> forecastItems)
        {
            return forecastItems
                .Select(item => item["weather"][0]["main"].ToString())
                .GroupBy(condition => condition)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }
        private string GetMostCommonIcon(IEnumerable<JToken> forecastItems)
        {
            return forecastItems
                .Select(item => item["weather"][0]["icon"].ToString())
                .GroupBy(icon => icon)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }
    }
}
