using Croppilot.Core.Features.Dashbored.Field.Results;

namespace Croppilot.Core.Features.Dashbored.Field.Models
{
    public class GetFieldById(int id) : IRequest<Response<GetFieldByIdResult>>
    {
        public int Id { get; set; } = id;
    }
}
