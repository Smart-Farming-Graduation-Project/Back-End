namespace Croppilot.Core.Features.Leasing.Query.Models
{
    public record GetLeasingByIdQuery(int Id) : IRequest<Response<Date.Models.Leasing?>>;

}
