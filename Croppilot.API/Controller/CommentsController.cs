using Croppilot.Core.Features.Comments.Command.Models;
using Croppilot.Core.Features.Comments.Query.Models;

namespace Croppilot.API.Controller;

/// <summary>
/// Controller responsible for handling operations related to comments, including retrieving comments for a post,
/// fetching a specific comment, creating, updating, and deleting comments.
/// </summary>
/// <remarks>
/// Some endpoints are publicly accessible while others require the user to be authenticated.
/// </remarks>
[SwaggerResponse(200, "Operation completed successfully"), SwaggerResponse(400, "Invalid operation or input data"),
 SwaggerResponse(401, "User is not authorized to perform this operation")]
// [EnableRateLimiting(RateLimiters.SocialEndpointsLimit)]
public class CommentsController : AppControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommentsController"/> class.
    /// </summary>
    /// <param name="mediator">The MediatR mediator instance used to send commands and queries.</param>
    public CommentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all top-level comments for a specific post.
    /// </summary>
    /// <param name="postId">The unique identifier of the post.</param>
    /// <returns>An IActionResult containing the list of comments or an error response.</returns>
    [ResponseCache(CacheProfileName = "Default"), HttpGet("GetComments/{postId}"), AllowAnonymous, SwaggerOperation(
         Summary = "Retrieve comments for a post",
         Description = "**Fetches all top-level comments for the specified post.**")]
    public async Task<IActionResult> GetCommentsByPost([FromRoute] int postId)
    {
        var query = new GetCommentsByPostQuery { PostId = postId };
        var response = await _mediator.Send(query);
        return NewResult(response);
    }

    /// <summary>
    /// Retrieves a specific comment by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the comment.</param>
    /// <returns>An IActionResult containing the comment details or an error response.</returns>
    [ResponseCache(CacheProfileName = "Default"), HttpGet("GetComment/{id}"), AllowAnonymous, SwaggerOperation(
         Summary = "Retrieve a specific comment",
         Description = "**Fetches the details of a comment by its ID.**")]
    public async Task<IActionResult> GetCommentById([FromRoute] int id)
    {
        var query = new GetCommentByIdQuery { Id = id };
        var response = await _mediator.Send(query);
        return NewResult(response);
    }

    /// <summary>
    /// Creates a new comment.
    /// </summary>
    /// <param name="command">The command object containing the details of the comment to create.</param>
    /// <returns>An IActionResult indicating whether the comment was created successfully.</returns>
    [HttpPost("CreateComment"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Create a new comment",
         Description =
             "**Creates a new comment by the authenticated user for a specified post. If the comment is a reply, provide a valid ParentCommentId; otherwise, use 0 or null.**")]
    public async Task<IActionResult> CreateComment([FromBody] AddCommentCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Updates an existing comment.
    /// </summary>
    /// <param name="id">The unique identifier of the comment to update.</param>
    /// <param name="command">The command object containing the updated comment details.</param>
    /// <returns>An IActionResult indicating whether the comment was updated successfully.</returns>
    [HttpPut("UpdateComment/{id}"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Update an existing comment",
         Description = "**Updates an existing comment if the authenticated user is the owner of the comment.**")]
    public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentCommand command)
    {
        command.Id = id;
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Deletes an existing comment.
    /// </summary>
    /// <param name="id">The unique identifier of the comment to delete.</param>
    /// <returns>An IActionResult indicating whether the comment was deleted successfully.</returns>
    [HttpDelete("DeleteComment/{id}"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Delete a comment",
         Description = "**Deletes a comment if the authenticated user is the owner of the comment.**")]
    public async Task<IActionResult> DeleteComment([FromRoute] int id)
    {
        var command = new DeleteCommentCommand { Id = id };
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
}
