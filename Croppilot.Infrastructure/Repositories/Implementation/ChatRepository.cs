namespace Croppilot.Infrastructure.Repositories.Implementation
{
    public class ChatRepository(AppDbContext context) : GenericRepository<ChatHistory>(context), IChatRepository;

}
