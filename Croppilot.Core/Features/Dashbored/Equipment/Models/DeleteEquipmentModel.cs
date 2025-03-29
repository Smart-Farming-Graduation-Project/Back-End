namespace Croppilot.Core.Features.Dashbored.Equipment.Models
{
    public class DeleteEquipmentModel(string id) : IRequest<Response<string>>
    {
        public string Id { get; set; } = id;
    }
}
