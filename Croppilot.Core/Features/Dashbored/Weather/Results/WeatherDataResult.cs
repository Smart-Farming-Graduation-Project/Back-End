namespace Croppilot.Core.Features.Dashbored.Weather.Results
{
    public class WeatherDataResult
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public DateTime LastUpdated { get; set; }
        public double UvIndex { get; set; }
        public double Pressure { get; set; }
    }
}
