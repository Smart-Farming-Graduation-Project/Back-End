
namespace Croppilot.Infrastructure.Repositories.Implementation
{
	public class ChatRepository(AppDbContext context) : GenericRepository<ChatHistory>(context), IChatRepository
	{
		public Task<List<ChatHistory>> GetChatHistoriesAsync(string userId, int limit = 10, DateTime? startDate = null, DateTime? endDate = null)
		{
			if (!endDate.HasValue) endDate = DateTime.UtcNow;
			if (!startDate.HasValue) startDate = endDate.Value.AddDays(-1); // Default to last 1 days if no date range is provided
			var query = _context.ChatHistories.AsQueryable();
			if (!string.IsNullOrEmpty(userId))
			{
				query = query.Where(chat => chat.UserId == userId);
			}
			query = query.Where(chat => chat.Timestamp >= startDate.Value && chat.Timestamp <= endDate.Value).Take(limit);
			return query.ToListAsync();
		}
	}
}
