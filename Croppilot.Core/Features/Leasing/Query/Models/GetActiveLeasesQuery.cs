namespace Croppilot.Core.Features.Leasing.Query.Models
{
    public record GetActiveLeasesQuery() : IRequest<Response<IEnumerable<Date.Models.Leasing>>>;

}
