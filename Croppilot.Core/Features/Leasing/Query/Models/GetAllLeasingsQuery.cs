using Croppilot.Core.Features.Leasing.Query.Result;

namespace Croppilot.Core.Features.Leasing.Query.Models
{
    public record GetAllLeasingsQuery() : IRequest<Response<IEnumerable<GetAllLeasingResult>>>;

}
