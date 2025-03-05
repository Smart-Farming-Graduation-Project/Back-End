namespace Croppilot.Core.Features.Reviews.Command.Models;

public class AddReviewCommand : IRequest<Response<string>>
{
    public int ProductID { get; set; }
    public string Headline { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; }
}