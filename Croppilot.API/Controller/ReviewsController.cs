using Croppilot.Core.Features.Reviews.Command.Models;
using Croppilot.Core.Features.Reviews.Query.Models;

namespace Croppilot.API.Controller;

public class ReviewsController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    : AppControllerBase
{
    // This endpoint is available to anyone.
    [HttpGet("GetReviews/{productId}")]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Gets reviews for a product",
        Description = "**Retrieves all reviews for a specified product.**")]
    public async Task<IActionResult> GetReviewsByProduct([FromRoute] int productId)
    {
        var query = new GetReviewsByProductQuery { ProductID = productId };
        var response = await mediator.Send(query);
        return NewResult(response);
    }

    // Only authenticated users can add reviews.
    [HttpPost("CreateReview")]
    [Authorize(Policy = nameof(UserRoleEnum.User))]
    [SwaggerOperation(Summary = "Creates a new review",
        Description = "**Creates a review for a product.**")]
    public async Task<IActionResult> CreateReview([FromBody] AddReviewCommand command)
    {
        command.UserID = GetCurrentUserId();
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    // Only the review's creator can delete it.
    [HttpDelete("DeleteReview/{reviewId}")]
    [Authorize(Policy = nameof(UserRoleEnum.User))]
    [SwaggerOperation(Summary = "Deletes a review",
        Description = "**Deletes a review by its ID (only if created by the authenticated user).**")]
    public async Task<IActionResult> DeleteReview([FromRoute] int reviewId)
    {
        var command = new DeleteReviewCommand
        {
            ReviewID = reviewId,
            CurrentUserID = GetCurrentUserId()
        };
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    /// <summary>
    /// Retrieves the current user's identifier from the HTTP context claims.
    /// </summary>
    /// <returns>The authenticated user's ID.</returns>
    private string GetCurrentUserId()
    {
        var userIdClaim = httpContextAccessor.HttpContext?.User
            .Claims.FirstOrDefault(c => c.Type == "NameIdentifier")?.Value;

        if (string.IsNullOrWhiteSpace(userIdClaim))
            throw new UnauthorizedAccessException("User not authenticated");

        return userIdClaim;
    }
}