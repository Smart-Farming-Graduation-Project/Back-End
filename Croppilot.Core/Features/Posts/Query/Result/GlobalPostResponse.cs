namespace Croppilot.Core.Features.Posts.Query.Result;

/// <summary>
/// Global post data without user-specific fields - used for caching core post information and single post retrieval
/// </summary>
public record GlobalPostResponse(
    int Id,
    string UserId,
    string UserName,
    string UserImageUrl,
    string Title,
    string Content,
    int VoteCount,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);