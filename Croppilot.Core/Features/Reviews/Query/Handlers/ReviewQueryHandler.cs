using Croppilot.Core.Features.Reviews.Query.Models;
using Croppilot.Core.Features.Reviews.Query.Result;

namespace Croppilot.Core.Features.Reviews.Query.Handlers;

public class ReviewQueryHandler(IReviewService reviewService) : ResponseHandler,
    IRequestHandler<GetReviewsByProductQuery, Response<List<ReviewResponse>>>
{
    public async Task<Response<List<ReviewResponse>>> Handle(GetReviewsByProductQuery request,
        CancellationToken cancellationToken)
    {
        var reviews = await reviewService.GetReviewsByProductIdAsync(request.ProductID, cancellationToken);
        if (reviews.Count == 0)
            return NotFound<List<ReviewResponse>>("No reviews found for this product.");

        var response = reviews.Select(r => new ReviewResponse
        {
            ReviewID = r.ReviewID,
            UserID = r.UserID,
            Headline = r.Headline,
            Rating = r.Rating,
            ReviewText = r.ReviewText,
            ReviewDate = r.ReviewDate
        }).ToList();

        return Success(response);
    }
}