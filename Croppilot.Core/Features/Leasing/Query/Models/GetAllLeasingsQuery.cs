namespace Croppilot.Core.Features.Leasing.Query.Models
{
    public record GetAllLeasingsQuery() : IRequest<Response<IEnumerable<Date.Models.Leasing>>>;

}
