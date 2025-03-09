using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services;

public class PostService(IPostRepository postRepository) : IPostService
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

    public async Task<OperationResult> DeletePostAsync(int id, CancellationToken cancellationToken = default)
    {
        var post = await postRepository.GetAsync(p => p.Id == id, cancellationToken: cancellationToken);
        if (post == null)
            return OperationResult.Failure;
        await postRepository.DeleteAsync(post, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<OperationResult> UpdatePostAsync(Post post, CancellationToken cancellationToken = default)
    {
        var currentPost = await postRepository.GetAsync(p => p.Id == post.Id, cancellationToken: cancellationToken);
        if (currentPost == null)
            return OperationResult.Failure;

        currentPost.Title = post.Title;
        currentPost.Content = post.Content;
        currentPost.VoteCount = post.VoteCount;
        currentPost.SharedPostId = post.SharedPostId;
        currentPost.UpdatedAt = DateTime.UtcNow;

        await postRepository.UpdateAsync(currentPost, cancellationToken);
        return OperationResult.Success;
    }
}