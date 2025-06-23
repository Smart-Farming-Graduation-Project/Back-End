using Croppilot.Core.Features.CosmosDb.Models;
using Croppilot.Core.Features.CosmosDb.Result;
using Croppilot.Services.Abstract.EmbbeddedServices;

namespace Croppilot.Core.Features.CosmosDb.Handlers
{
    public class CosmseDbHnadlers(ICosmosDbService cosmosDbService) : ResponseHandler,
        //IRequestHandler<ReadingRequest, Response<GetIotDataResult>>,
        IRequestHandler<GetIoTData, Response<List<GetIotDataResult>>>,
        IRequestHandler<AllReadingRequest, Response<List<GetIotDataResult>>>,
        IRequestHandler<GetReadingByDevice, Response<List<GetIotDataResult>>>
    {
        //public async Task<Response<GetIotDataResult>> Handle(ReadingRequest request,
        //    CancellationToken cancellationToken)
        //{
        //    var reading = await cosmosDbService.GetItemAsync<GetIotDataResult>(request.Id, request.PartitionKey);
        //    if (reading == null)
        //    {
        //        return NotFound<GetIotDataResult>("Reading Not Found");
        //    }

        //    return Success(reading, meta: new Dictionary<string, object>
        //    {
        //        { "count", 1 }
        //    });

        //}

        public async Task<Response<List<GetIotDataResult>>> Handle(GetIoTData request, CancellationToken cancellationToken)
        {
            string query = "SELECT * FROM c ORDER BY c.timestamp DESC OFFSET 0 LIMIT 10";
            var data = await cosmosDbService.QueryItemsAsync<GetIotDataResult>(query);

            var result = Success(data);
            result.Meta = new Dictionary<string, object> { { "count", data.Count } };

            return result;
        }


        public async Task<Response<List<GetIotDataResult>>> Handle(AllReadingRequest request, CancellationToken cancellationToken)
        {
            string query = "SELECT * FROM c";
            var data = await cosmosDbService.QueryItemsAsync<GetIotDataResult>(query);

            var result = Success(data);
            result.Meta = new Dictionary<string, object> { { "count", data.Count } };

            return result;
        }


        public async Task<Response<List<GetIotDataResult>>> Handle(GetReadingByDevice request, CancellationToken cancellationToken)
        {
            string query = $"SELECT * FROM c WHERE c.deviceId = '{request.PartitionKey}'";
            var data = await cosmosDbService.QueryItemsAsync<GetIotDataResult>(query);
            if (data.Count <= 0)
                return NotFound<List<GetIotDataResult>>("This Device Not Found");
            var result = Success(data);
            result.Meta = new Dictionary<string, object> { { "count", data.Count } };

            return result;
        }
    }
}
