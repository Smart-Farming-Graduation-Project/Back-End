using Croppilot.Core.Features.Leasing.Query.Result;

namespace Croppilot.Core.Features.Leasing.Query.Models
{
    public record GetActiveLeasesQuery() : IRequest<Response<IEnumerable<GetAllActiveLeasingResult>>>;

}
