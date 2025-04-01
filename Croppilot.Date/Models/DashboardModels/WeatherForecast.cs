namespace Croppilot.Date.Models.DashboardModels
{
    public class WeatherForecast
    {
        public int Id { get; set; }
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
