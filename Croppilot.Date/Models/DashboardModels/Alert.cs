using Croppilot.Date.Helpers.Dashboard.Enum;

namespace Croppilot.Date.Models.DashboardModels
{
    public class Alert
    {
        public int Id { get; set; }
        public EmergencyType EmergencyType { get; set; }
        public string Message { get; set; }
        public SeverityType Severity { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
