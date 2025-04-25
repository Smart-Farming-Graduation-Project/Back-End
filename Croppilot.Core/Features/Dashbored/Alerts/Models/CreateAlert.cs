using Croppilot.Date.Helpers.Dashboard.Enum;

namespace Croppilot.Core.Features.Dashbored.Alerts.Models
{
    public class CreateAlert : IRequest<Response<string>>
    {
        public EmergencyType EmergencyType { get; set; }
        public string Message { get; set; }
        public SeverityType Severity { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LocationDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
