namespace Croppilot.Core.Features.Dashbored.Equipment.Models
{
    public class UpdateEquipmentStatusModel(string status) : IRequest<Response<string>>
    {
        public string EquipmentId { get; set; }
        public string Status { get; set; } = status;
    }
}
