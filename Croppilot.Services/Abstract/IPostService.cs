namespace Croppilot.Services.Abstract;

public interface IPostService
{
    Task<OperationResult> AddPostAsync(Post post, CancellationToken cancellationToken = default);
    Task<List<Post>> GetAllPostsAsync(CancellationToken cancellationToken = default);
    Task<Post?> GetPostByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<OperationResult> DeletePostAsync(int id, CancellationToken cancellationToken = default);
    Task<OperationResult> UpdatePostAsync(Post post, CancellationToken cancellationToken = default);
}