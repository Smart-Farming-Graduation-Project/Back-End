using Croppilot.Core.Features.Posts.Command.Models;
using Croppilot.Core.Features.Posts.Query.Models;

namespace Croppilot.API.Controller;

[ApiController]
[Route("[controller]")]
public class PostsController(IMediator mediator) : AppControllerBase
{
    // Get all posts
    [HttpGet("GetPosts")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPosts()
    {
        var query = new GetPostsQuery();
        var response = await mediator.Send(query);
        return NewResult(response);
    }

    // Get a post by its ID
    [HttpGet("GetPost/{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPostById([FromRoute] int id)
    {
        var query = new GetPostByIdQuery { Id = id };
        var response = await mediator.Send(query);
        return NewResult(response);
    }

    // Create a new post
    [HttpPost("CreatePost")]
    [Authorize(Policy = nameof(UserRoleEnum.User))]
    public async Task<IActionResult> CreatePost([FromBody] AddPostCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    // Update an existing post (only by its creator)
    [HttpPut("UpdatePost/{id}")]
    [Authorize(Policy = nameof(UserRoleEnum.User))]
    public async Task<IActionResult> UpdatePost([FromRoute] int id, [FromBody] UpdatePostCommand command)
    {
        command.Id = id;
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    // Delete a post (only by its creator)
    [HttpDelete("DeletePost/{id}")]
    [Authorize(Policy = nameof(UserRoleEnum.User))]
    public async Task<IActionResult> DeletePost([FromRoute] int id)
    {
        var command = new DeletePostCommand { Id = id };
        var response = await mediator.Send(command);
        return NewResult(response);
    }
}