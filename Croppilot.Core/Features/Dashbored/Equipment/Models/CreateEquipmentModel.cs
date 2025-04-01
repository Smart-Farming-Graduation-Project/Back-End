namespace Croppilot.Core.Features.Dashbored.Equipment.Models
{
    public class CreateEquipmentModel : IRequest<Response<string>>
    {
        public string EquipmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; }
        public DateTime LastMaintenance { get; set; } = DateTime.UtcNow;
        public double HoursUsed { get; set; }
        public double Battery { get; set; }
        public string Connectivity { get; set; }
    }
}
