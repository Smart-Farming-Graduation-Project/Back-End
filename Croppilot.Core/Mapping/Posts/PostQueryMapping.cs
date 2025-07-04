using Croppilot.Core.Features.Posts.Query.Result;

namespace Croppilot.Core.Mapping.Posts;

public class PostQueryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Mapping for PostResponse from Post
        config.NewConfig<Date.Models.Post, PostResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0); // Will be set separately

        // Mapping for GlobalPostResponse from Post (without user-specific data)
        config.NewConfig<Date.Models.Post, GlobalPostResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);

        // Mapping for GlobalPostByIdResponse from Post (without user-specific data)
        config.NewConfig<Date.Models.Post, GlobalPostByIdResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt);

        // Helper mappings for merging global and user-specific data
        config.NewConfig<GlobalPostResponse, PostResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0); // Will be set separately

        config.NewConfig<GlobalPostByIdResponse, PostResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Content, src => src.Content)
            .Map(dest => dest.VoteCount, src => src.VoteCount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.UpdatedAt, src => src.UpdatedAt)
            .Map(dest => dest.UserVoteStatus, src => 0); // Will be set separately
    }
} 