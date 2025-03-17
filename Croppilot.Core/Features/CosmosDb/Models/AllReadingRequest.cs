using Croppilot.Core.Features.CosmosDb.Result;

namespace Croppilot.Core.Features.CosmosDb.Models
{
    public class AllReadingRequest : IRequest<Response<List<GetIotDataResult>>>
    {
    }
}
