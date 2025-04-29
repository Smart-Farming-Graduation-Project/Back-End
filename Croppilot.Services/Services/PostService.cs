using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services;

public class PostService(IPostRepository postRepository, ICommentRepository commentRepository) : IPostService
{
    public async Task<OperationResult> AddPostAsync(Post post, CancellationToken cancellationToken = default)
    {
        await postRepository.AddAsync(post, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<List<Post>> GetAllPostsAsync(CancellationToken cancellationToken = default)
    {
        return await postRepository.GetAllAsync(cancellationToken: cancellationToken);
    }

    public async Task<Post?> GetPostByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await postRepository.GetAsync(p => p.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<OperationResult> UpdatePostAsync(Post post, CancellationToken cancellationToken = default)
    {
        var currentPost = await postRepository.GetAsync(p => p.Id == post.Id, cancellationToken: cancellationToken);
        if (currentPost == null)
            return OperationResult.Failure;

        currentPost.Title = post.Title;
        currentPost.Content = post.Content;
        currentPost.VoteCount = post.VoteCount;
        currentPost.UpdatedAt = DateTime.UtcNow;

        await postRepository.UpdateAsync(currentPost, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<OperationResult> DeletePostAsync(int postId, CancellationToken cancellationToken = default)
    {
        // Now delete the post.
        var post = await postRepository.GetAsync(p => p.Id == postId, cancellationToken: cancellationToken);
        if (post == null)
            return OperationResult.Failure;

        // Retrieve all comments for the post.
        var comments = await commentRepository.GetAllAsync(
            filter: c => c.PostId == postId,
            cancellationToken: cancellationToken);

        // Delete each comment recursively.
        foreach (var comment in comments)
        {
            await DeleteCommentRecursively(comment.Id);
        }

        await postRepository.DeleteAsync(post, CancellationToken.None);
        return OperationResult.Success;
    }

    private async Task DeleteCommentRecursively(int commentId)
    {
        // Retrieve child replies.
        var childComments = await commentRepository.GetAllAsync(
            filter: c => c.ParentCommentId == commentId,
            cancellationToken: CancellationToken.None);

        foreach (var child in childComments)
        {
            await DeleteCommentRecursively(child.Id);
        }

        // Delete the comment.
        var comment =
            await commentRepository.GetAsync(c => c.Id == commentId, cancellationToken: CancellationToken.None);
        if (comment != null)
        {
            await commentRepository.DeleteAsync(comment, cancellationToken: CancellationToken.None);
        }
    }
}