namespace Croppilot.Services.Abstract.EmbbeddedServices
{
    public interface ICosmosDbService
    {
        Task<T> GetItemAsync<T>(string id, string partitionKey);
        Task<List<T>> QueryItemsAsync<T>(string query);
        //Task<List<T>> QueryAllItemsAsync<T>(string query);
    }
}
