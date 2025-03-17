using Croppilot.Core.Features.CosmosDb.Result;

namespace Croppilot.Core.Features.CosmosDb.Models
{
    public class ReadingRequest(string id, string partitionId) : IRequest<Response<GetIotDataResult>>
    {
        public string Id { get; set; } = id;
        public string PartitionKey { get; set; } = partitionId;
    }
}

