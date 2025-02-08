using Croppilot.Core.Features.Leasing.Query.Result;

namespace Croppilot.Core.Features.Leasing.Query.Models
{
    public record GetLeasingsByProductIdQuery(int ProductId) : IRequest<Response<GetAllActiveLeasingResult>>;

}
