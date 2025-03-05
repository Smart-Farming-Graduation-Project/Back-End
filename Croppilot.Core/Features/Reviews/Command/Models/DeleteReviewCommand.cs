namespace Croppilot.Core.Features.Reviews.Command.Models;

public class DeleteReviewCommand : IRequest<Response<string>>
{
    public int ReviewID { get; set; }
}