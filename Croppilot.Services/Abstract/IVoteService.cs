namespace Croppilot.Services.Abstract;

public interface IVoteService
{
    Task<OperationResult> AddOrUpdateVoteAsync(Vote vote, CancellationToken cancellationToken = default);
    Task<OperationResult> DeleteVoteAsync(string userId, int targetId, string targetType, CancellationToken cancellationToken = default);
    Task<Vote?> GetVoteAsync(string userId, int targetId, string targetType, CancellationToken cancellationToken = default);
}