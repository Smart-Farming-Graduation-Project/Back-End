namespace Croppilot.Core.Features.Posts.Query.Result;

// Complete response including user-specific data for GetAllPosts
public record GetAllPostsResponse(
    int Id,
    string UserId,
    string UserName,
    string UserImageUrl,
    string Title,
    string Content,
    int VoteCount,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    int UserVoteStatus // 1 for upvote, 0 for no vote, -1 for downvote
); 