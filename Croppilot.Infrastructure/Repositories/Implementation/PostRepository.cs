namespace Croppilot.Infrastructure.Repositories.Implementation;

public class PostRepository(AppDbContext context) : GenericRepository<Post>(context), IPostRepository
{
    
}