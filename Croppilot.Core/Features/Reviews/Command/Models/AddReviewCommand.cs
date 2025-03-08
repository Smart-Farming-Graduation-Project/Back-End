namespace Croppilot.Core.Features.Reviews.Command.Models;

public class AddReviewCommand : IRequest<Response<string>>
{
    public int ProductID { get; }
    public string Headline { get; }
    public int Rating { get; }
    public string ReviewText { get; }
}