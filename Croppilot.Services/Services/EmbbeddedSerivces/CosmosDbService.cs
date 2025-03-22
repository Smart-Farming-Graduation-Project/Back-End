using Croppilot.Services.Abstract.EmbbeddedServices;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace Croppilot.Services.Services.EmbbeddedSerivces
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container _container;

        public CosmosDbService(CosmosClient cosmosClient, IConfiguration config)
        {
            var databaseId = config["AzureService:CosmosDb:DatabaseId"];
            var containerId = config["AzureService:CosmosDb:ContainerId"];
            _container = cosmosClient.GetContainer(databaseId, containerId);
        }



        public async Task<T> GetItemAsync<T>(string id, string partitionKey)
        {
            try
            {
                var response = await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default;
            }
        }


        public async Task<List<T>> QueryItemsAsync<T>(string query)
        {
            var queryDef = new QueryDefinition(query);
            var iterator = _container.GetItemQueryIterator<T>(queryDef);
            var results = new List<T>();

            while (iterator.HasMoreResults)
            {
                var response = await iterator.ReadNextAsync();
                results.AddRange(response);
            }

            return results;
        }


    }
}
