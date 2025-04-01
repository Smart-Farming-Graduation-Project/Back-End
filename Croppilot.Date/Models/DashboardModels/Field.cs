using Croppilot.Date.Helpers.Dashboard.Enum;

namespace Croppilot.Date.Models.DashboardModels
{
    public class Field
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Size { get; set; }
        public string Crop { get; set; } = string.Empty;
        public DateTime PlantingDate { get; set; }
        public DateTime HarvestDate { get; set; }
        public IrrigationType Irrigation { get; set; } = IrrigationType.None;
        public FieldStatus Status { get; set; } = FieldStatus.Planted;
    }
}
