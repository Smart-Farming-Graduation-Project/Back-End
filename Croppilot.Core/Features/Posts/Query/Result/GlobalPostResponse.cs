namespace Croppilot.Core.Features.Posts.Query.Result;

public record GlobalPostByIdResponse(
    int Id,
    string UserId,
    string Title,
    string Content,
    int VoteCount,
    DateTime CreatedAt,
    DateTime? UpdatedAt
); 