using Croppilot.Core.Features.Posts.Command.Models;
using Croppilot.Core.Features.Posts.Query.Models;

namespace Croppilot.API.Controller;

/// <summary>
/// Controller responsible for handling operations related to posts, including retrieving all posts,
/// fetching a specific post by ID, creating a new post, updating an existing post, and deleting a post.
/// </summary>
/// <remarks>
/// Some endpoints are available to all users, while others require the user to be authenticated.
/// </remarks>
[SwaggerResponse(200, "Operation completed successfully"), SwaggerResponse(400, "Invalid operation or input data"),
 SwaggerResponse(401, "User is not authorized to perform this operation")]
[EnableRateLimiting(RateLimiters.SocialEndpointsLimit)]
public class PostsController(IMediator mediator) : AppControllerBase
{
    /// <summary>
    /// Retrieves all posts.
    /// </summary>
    /// <returns>
    /// An <see cref="IActionResult"/> containing a list of posts or an error response.
    /// </returns>
    [ResponseCache(CacheProfileName = "Default"), HttpGet("GetPosts"), AllowAnonymous, SwaggerOperation(
         Summary = "Retrieve all posts",
         Description = "**Fetches all posts available in the system.**")]
    public async Task<IActionResult> GetPosts()
    {
        var query = new GetPostsQuery();
        var response = await mediator.Send(query);
        return NewResult(response);
    }

    /// <summary>
    /// Retrieves a specific post by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the post to retrieve.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the post details or an error response.
    /// </returns>
    [ResponseCache(CacheProfileName = "Default"), HttpGet("GetPost/{id}"), AllowAnonymous, SwaggerOperation(
         Summary = "Retrieve a specific post",
         Description = "**Fetches the details of a post by its ID.**")]
    public async Task<IActionResult> GetPostById([FromRoute] int id)
    {
        var query = new GetPostByIdQuery { Id = id };
        var response = await mediator.Send(query);
        return NewResult(response);
    }

    /// <summary>
    /// Creates a new post.
    /// </summary>
    /// <param name="command">The command object containing the details of the post to create.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> indicating whether the post was created successfully.
    /// </returns>
    [HttpPost("CreatePost"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Create a new post",
         Description =
             "**Creates a new post by the authenticated user. If the post is a share, provide a valid SharedPostId; otherwise, use 0 or null.**")]
    public async Task<IActionResult> CreatePost([FromBody] AddPostCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Updates an existing post.
    /// </summary>
    /// <param name="id">The unique identifier of the post to update.</param>
    /// <param name="command">The command object containing the updated post details.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> indicating whether the post was updated successfully.
    /// </returns>
    [HttpPut("UpdatePost/{id}"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Update an existing post",
         Description = "**Updates an existing post if the authenticated user is the creator.**")]
    public async Task<IActionResult> UpdatePost([FromRoute] int id, [FromBody] UpdatePostCommand command)
    {
        command.Id = id;
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Deletes an existing post.
    /// </summary>
    /// <param name="id">The unique identifier of the post to delete.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> indicating whether the post was deleted successfully.
    /// </returns>
    [HttpDelete("DeletePost/{id}"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Delete a post",
         Description = "**Deletes a post if the authenticated user is the creator.**")]
    public async Task<IActionResult> DeletePost([FromRoute] int id)
    {
        var command = new DeletePostCommand { Id = id };
        var response = await mediator.Send(command);
        return NewResult(response);
    }
}