namespace Croppilot.Core.Features.Posts.Query.Result;

/// <summary>
/// Global post data without user-specific fields - used for caching core post information
/// </summary>
public record GlobalPostResponse(
    int Id,
    string UserId,
    string Title,
    string Content,
    int VoteCount,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

/// <summary>
/// Global post data for single post retrieval without user-specific fields
/// </summary>
public record GlobalPostByIdResponse(
    int Id,
    string UserId,
    string Title,
    string Content,
    int VoteCount,
    DateTime CreatedAt,
    DateTime? UpdatedAt
); 