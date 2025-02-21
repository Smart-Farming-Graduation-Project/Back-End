namespace Croppilot.Core.Features.Reviews.Query.Result;

public class ReviewResponse
{
    public int ReviewID { get; set; }
    public string UserID { get; set; }
    public string Headline { get; set; }
    public int Rating { get; set; }
    public string? ReviewText { get; set; }
    public DateTime ReviewDate { get; set; }
}