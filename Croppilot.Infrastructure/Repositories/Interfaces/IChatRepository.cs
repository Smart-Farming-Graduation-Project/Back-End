namespace Croppilot.Infrastructure.Repositories.Interfaces
{
	public interface IChatRepository : IGenericRepository<ChatHistory>
	{
		Task<List<ChatHistory>> GetChatHistoriesAsync(string userId, int limit = 10, DateTime? startDate = null, DateTime? endDate = null);
	}
}
