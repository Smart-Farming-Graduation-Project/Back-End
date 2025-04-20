namespace Croppilot.Date.Models.DashboardModels
{
    public class FarmerAdminDashboard
    {
        public int Id { get; set; }

        public string AdminUserId { get; set; }
        public ApplicationUser AdminUser { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<WeatherData> WeatherData { get; set; }
        public ICollection<WeatherForecast> WeatherForecasts { get; set; }
        public ICollection<Field> Fields { get; set; }
        public ICollection<Equipment> Equipments { get; set; }

    }

}
