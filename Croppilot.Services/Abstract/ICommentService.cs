namespace Croppilot.Services.Abstract;

public interface ICommentService
{
    Task<OperationResult> AddCommentAsync(Comment comment, CancellationToken cancellationToken = default);
    Task<Comment?> GetCommentByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<Comment>> GetCommentsByPostIdAsync(int postId, CancellationToken cancellationToken = default);
    Task<List<Comment>> GetRepliesByCommentIdAsync(int commentId, CancellationToken cancellationToken = default);
    Task<OperationResult> DeleteCommentAsync(int id, CancellationToken cancellationToken = default);
    Task<OperationResult> UpdateCommentAsync(Comment comment, CancellationToken cancellationToken = default);
}