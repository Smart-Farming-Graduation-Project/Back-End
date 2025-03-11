using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services;

public class CommentService(ICommentRepository commentRepository) : ICommentService
{
    public async Task<OperationResult> AddCommentAsync(Comment comment, CancellationToken cancellationToken = default)
    {
        await commentRepository.AddAsync(comment, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<List<Comment>> GetAllCommentsAsync(CancellationToken cancellationToken = default)
    {
        return await commentRepository.GetAllAsync(cancellationToken: cancellationToken);
    }

    public async Task<Comment?> GetCommentByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await commentRepository.GetAsync(c => c.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId, CancellationToken cancellationToken = default)
    {
        return await commentRepository.GetAllAsync(c => c.PostId == postId, cancellationToken: cancellationToken);
    }

    public async Task<List<Comment>> GetRepliesByCommentIdAsync(int commentId,
        CancellationToken cancellationToken = default)
    {
        return await commentRepository.GetAllAsync(
            c => c.ParentCommentId == commentId, // Filter by ParentCommentId
            cancellationToken: cancellationToken
        );
    }

    public async Task<OperationResult> DeleteCommentAsync(int commentId, CancellationToken cancellationToken = default)
    {
        // Fetch the comment to delete.
        var comment = await commentRepository.GetAsync(c => c.Id == commentId, cancellationToken: cancellationToken);
        if (comment == null)
            return OperationResult.Failure;

        // Recursively delete child comments.
        await DeleteChildCommentsAsync(commentId, cancellationToken);

        // Delete the comment itself.
        await commentRepository.DeleteAsync(comment, CancellationToken.None);
        return OperationResult.Success;
    }

    public async Task<OperationResult> UpdateCommentAsync(Comment comment,
        CancellationToken cancellationToken = default)
    {
        var currentComment =
            await commentRepository.GetAsync(c => c.Id == comment.Id, cancellationToken: cancellationToken);
        if (currentComment == null)
            return OperationResult.Failure;

        currentComment.Content = comment.Content;
        currentComment.VoteCount = comment.VoteCount;
        currentComment.UpdatedAt = DateTime.UtcNow;

        await commentRepository.UpdateAsync(currentComment, cancellationToken);
        return OperationResult.Success;
    }

    private async Task DeleteChildCommentsAsync(int parentCommentId, CancellationToken cancellationToken)
    {
        // Retrieve all direct replies to the given comment.
        var childComments = await commentRepository.GetAllAsync(
            filter: c => c.ParentCommentId == parentCommentId,
            cancellationToken: cancellationToken);

        foreach (var child in childComments)
        {
            // Recursively delete any replies to this child comment.
            await DeleteChildCommentsAsync(child.Id, CancellationToken.None);
            // Delete the child comment.
            await commentRepository.DeleteAsync(child, CancellationToken.None);
        }
    }
}