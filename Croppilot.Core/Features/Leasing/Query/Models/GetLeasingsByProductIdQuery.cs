namespace Croppilot.Core.Features.Leasing.Query.Models
{
    public record GetLeasingsByProductIdQuery(int ProductId) : IRequest<Response<IEnumerable<Date.Models.Leasing>>>;

}
