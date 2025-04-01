using Croppilot.Date.Helpers.Dashboard.Enum;

namespace Croppilot.Core.Features.Dashbored.Field.Models
{
    public class CreateFieldModel : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public double Size { get; set; }
        public string Crop { get; set; }
        public DateTime PlantingDate { get; set; } = DateTime.UtcNow;
        public DateTime HarvestDate { get; set; }
        public IrrigationType Irrigation { get; set; }
        public FieldStatus Status { get; set; }
    }
}
