using Croppilot.Core.Features.Leasing.Query.Result;

namespace Croppilot.Core.Features.Leasing.Query.Models
{
    public record GetLeasingByIdQuery(int Id) : IRequest<Response<GetAllActiveLeasingResult>>;

}
