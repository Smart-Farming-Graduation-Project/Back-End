namespace Croppilot.Core.Features.Dashbored.Weather.Results
{
    public class WeatherForcastResult
    {
        public DateTime Date { get; set; }
        public string Condition { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Precipitation { get; set; }
        public double Wind { get; set; }
        public string Day { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
        public string Icon { get; set; }
    }
}
