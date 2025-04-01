namespace Croppilot.Core.Features.Dashbored.Field.Models
{
    public class DeleteFieldModel(int id) : IRequest<Response<string>>
    {
        public int Id { get; set; } = id;
    }
}
