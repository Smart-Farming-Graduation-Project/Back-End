namespace Croppilot.Core.Features.Reviews.Command.Models;

public class UpdateReviewCommand : IRequest<Response<string>>
{
    public int ReviewID { get; set; }
    public string Headline { get; set; }
    public double Rating { get; set; }

    public string? ReviewText { get; set; }
}