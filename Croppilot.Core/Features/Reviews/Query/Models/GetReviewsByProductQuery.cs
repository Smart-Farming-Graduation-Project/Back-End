using Croppilot.Core.Features.Reviews.Query.Result;

namespace Croppilot.Core.Features.Reviews.Query.Models;

public class GetReviewsByProductQuery : IRequest<Response<List<ReviewResponse>>>
{
    public int ProductID { get; set; }
}