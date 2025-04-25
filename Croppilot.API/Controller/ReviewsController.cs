using Croppilot.Core.Features.Reviews.Command.Models;
using Croppilot.Core.Features.Reviews.Query.Models;

namespace Croppilot.API.Controller;

public class ReviewsController(IMediator mediator)
    : AppControllerBase
{
    // This endpoint is available to anyone.
    [ResponseCache(CacheProfileName = "Default"), HttpGet("GetReviews/{productId}"), AllowAnonymous, SwaggerOperation(
         Summary = "Gets reviews for a product",
         Description = "**Retrieves all reviews for a specified product.**")]
    [EnableRateLimiting(RateLimiters.SocialEndpointsLimit)]
    public async Task<IActionResult> GetReviewsByProduct([FromRoute] int productId)
    {
        var query = new GetReviewsByProductQuery { ProductID = productId };
        var response = await mediator.Send(query);
        return NewResult(response);
    }

    // Only authenticated users can add reviews.
    [HttpPost("CreateReview"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Creates a new review",
         Description = "**Creates a review for a product, user need to be authenticated.**")]
    public async Task<IActionResult> CreateReview([FromBody] AddReviewCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    // Only the review's creator can delete it.
    [HttpDelete("DeleteReview/{reviewId}"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Deletes a review",
         Description = "**Deletes a review by its ID (only if created by the authenticated user).**")]
    public async Task<IActionResult> DeleteReview([FromRoute] int reviewId)
    {
        var command = new DeleteReviewCommand
        {
            ReviewID = reviewId,
        };

        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("UpdateReview/{reviewId}"), Authorize(Policy = nameof(UserRoleEnum.User)), SwaggerOperation(
         Summary = "Updates a review",
         Description = "**Updates an existing review if the authenticated user is the creator.**")]
    public async Task<IActionResult> UpdateReview([FromRoute] int reviewId, [FromBody] UpdateReviewCommand command)
    {
        command.ReviewID = reviewId;
        var response = await mediator.Send(command);
        return NewResult(response);
    }
}