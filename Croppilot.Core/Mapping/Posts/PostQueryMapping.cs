using Croppilot.Core.Features.Posts.Query.Result;

namespace Croppilot.Core.Mapping.Posts;

public class PostQueryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Mapping for PostResponse from Post (legacy - keeping for backward compatibility)
        config.NewConfig<Date.Models.Post, PostResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0) // Will be set separately
            .Map(dest => dest.UserName, src => $"{src.User.FirstName} {src.User.LastName}")
            .Map(dest => dest.UserImageUrl, src => src.User.ImageUrl);

        // Mapping for GlobalPostResponse from Post (without user-specific data)
        // Used for caching core post information and single post retrieval
        config.NewConfig<Date.Models.Post, GlobalPostResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserName, src => $"{src.User.FirstName} {src.User.LastName}")
            .Map(dest => dest.UserImageUrl, src => src.User.ImageUrl);

        // Mappings for new specific response models from Post
        config.NewConfig<Date.Models.Post, GetAllPostsResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0) // Will be set separately
            .Map(dest => dest.UserName, src => $"{src.User.FirstName} {src.User.LastName}")
            .Map(dest => dest.UserImageUrl, src => src.User.ImageUrl);

        config.NewConfig<Date.Models.Post, GetPostByIdResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0) // Will be set separately
            .Map(dest => dest.UserName, src => $"{src.User.FirstName} {src.User.LastName}")
            .Map(dest => dest.UserImageUrl, src => src.User.ImageUrl);

        config.NewConfig<Date.Models.Post, GetPostsByUserIdResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0) // Will be set separately
            .Map(dest => dest.UserName, src => $"{src.User.FirstName} {src.User.LastName}")
            .Map(dest => dest.UserImageUrl, src => src.User.ImageUrl);

        // Helper mappings for merging global and user-specific data
        config.NewConfig<GlobalPostResponse, PostResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0) // Will be set separately
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.UserImageUrl, src => src.UserImageUrl);

        config.NewConfig<GlobalPostResponse, GetAllPostsResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0) // Will be set separately
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.UserImageUrl, src => src.UserImageUrl);

        config.NewConfig<GlobalPostResponse, GetPostByIdResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0) // Will be set separately
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.UserImageUrl, src => src.UserImageUrl);

        config.NewConfig<GlobalPostResponse, GetPostsByUserIdResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0) // Will be set separately
            .Map(dest => dest.UserName, src => src.UserName)
            .Map(dest => dest.UserImageUrl, src => src.UserImageUrl);
    }
} 