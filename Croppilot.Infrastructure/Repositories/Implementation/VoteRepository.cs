namespace Croppilot.Infrastructure.Repositories.Implementation;

public class VoteRepository(AppDbContext context) : GenericRepository<Vote>(context), IVoteRepository
{
    public async Task<Vote?> GetVoteByUserAndTargetAsync(string userId, int targetId, string targetType,
        CancellationToken cancellationToken = default)
    {
        return await _context.Set<Vote>()
            .FirstOrDefaultAsync(v => v.UserId == userId
                                      && v.TargetId == targetId
                                      && v.TargetType == targetType, cancellationToken);
    }

    public async Task<List<Vote>> GetUserVotesForPostsAsync(string userId, List<int> postIds, CancellationToken cancellationToken = default)
    {
        return await _context.Set<Vote>()
            .Where(v => v.UserId == userId
                        && postIds.Contains(v.TargetId)
                        && v.TargetType == "post")
            .ToListAsync(cancellationToken);
    }
}