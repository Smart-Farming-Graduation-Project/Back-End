namespace Croppilot.Infrastructure.Repositories.Interfaces;

public interface IVoteRepository : IGenericRepository<Vote>
{
    Task<Vote?> GetVoteByUserAndTargetAsync(string userId, int targetId, string targetType, CancellationToken cancellationToken = default);
}