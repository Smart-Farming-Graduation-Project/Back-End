using Croppilot.Date.Helpers.Dashboard.Enum;

namespace Croppilot.Date.Models.DashboardModels
{
    public class Equipment
    {
        public int Id { get; set; }
        public string EquipmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public EquipmentStatus Status { get; set; } = EquipmentStatus.Idle;
        public DateTime LastMaintenance { get; set; }
        private double _hoursUsed;

        public double HoursUsed
        {
            get => _hoursUsed;
            set => _hoursUsed = Math.Max(0, value); // Prevent negative hours
        }
        private double _battery;
        public double Battery
        {
            get => _battery;
            set => _battery = Math.Clamp(value, 0, 100); // Ensure 0-100 range
        }
        public EquipmentConnectivity Connectivity { get; set; } = EquipmentConnectivity.Offline;

        //public int FarmerAdminDashboardId { get; set; }
        //public FarmerAdminDashboard FarmerAdminDashboard { get; set; }
    }
}
