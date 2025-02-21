namespace Croppilot.Core.Features.Reviews.Command.Models;

public class UpdateReviewCommand : IRequest<Response<string>>
{
    public int ReviewID { get; set; }
    public string Headline { get; set; }
    public int Rating { get; set; }

    public string ReviewText { get; set; }

    // This property will be set from the authenticated context
    public string CurrentUserID { get; set; }
}