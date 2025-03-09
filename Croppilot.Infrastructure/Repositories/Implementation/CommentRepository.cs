namespace Croppilot.Infrastructure.Repositories.Implementation;

public class CommentRepository(AppDbContext context) : GenericRepository<Comment>(context), ICommentRepository
{
}