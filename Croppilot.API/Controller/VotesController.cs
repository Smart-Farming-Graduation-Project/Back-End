using Croppilot.Core.Features.Votes.Command.Models;


namespace Croppilot.API.Controller;

/// <summary>
/// Controller responsible for handling voting operations for posts and comments.
/// </summary>
/// <remarks>
/// Endpoints here allow an authenticated user to record (or update) and delete votes on a target content.
/// </remarks>
[SwaggerResponse(200, "Operation completed successfully"), SwaggerResponse(400, "Invalid operation or input data"),
 SwaggerResponse(401, "User is not authorized to perform this operation")]
public class VotesController(IMediator mediator) : AppControllerBase
{
    /// <summary>
    /// Records or updates a vote for a target (post or comment) by the authenticated user.
    /// </summary>
    /// <param name="command">The command object containing target ID, target type, and vote type.</param>
    /// <returns>An IActionResult indicating the result of the vote operation.</returns>
    [HttpPost("Vote"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Record or update a vote",
         Description =
             "**Records a vote for a target (post or comment) by the authenticated user. VoteType should be 1 for upvote or -1 for downvote.**")]
    public async Task<IActionResult> Vote([FromBody] AddOrUpdateVoteCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Deletes a vote for a target (post or comment) by the authenticated user.
    /// </summary>
    /// <param name="command">The command object containing the target ID and target type.</param>
    /// <returns>An IActionResult indicating whether the vote was deleted successfully.</returns>
    [HttpDelete("DeleteVote"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Delete a vote",
         Description = "**Deletes the vote for a specified target (post or comment) by the authenticated user.**")]
    public async Task<IActionResult> DeleteVote([FromBody] DeleteVoteCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }
}
