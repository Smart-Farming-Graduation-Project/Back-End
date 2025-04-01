using Croppilot.Date.Helpers.Dashboard.Enum;

namespace Croppilot.Core.Features.Dashbored.Field.Models
{
    public class UpdateFieldModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public string Crop { get; set; }
        public DateTime PlantingDate { get; set; }
        public DateTime HarvestDate { get; set; }
        public IrrigationType Irrigation { get; set; }
        public FieldStatus Status { get; set; }
    }
}
