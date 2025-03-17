using Croppilot.Core.Features.CosmosDb.Result;

namespace Croppilot.Core.Features.CosmosDb.Models
{
    public class GetReadingByDevice(string partitionId) : IRequest<Response<List<GetIotDataResult>>>
    {
        public string PartitionKey { get; set; } = partitionId;

    }
}
