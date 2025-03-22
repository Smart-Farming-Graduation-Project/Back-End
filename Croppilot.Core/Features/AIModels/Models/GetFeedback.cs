using Croppilot.Core.Features.AIModels.Results;

namespace Croppilot.Core.Features.AIModels.Models
{
    public class GetFeedback(Guid imageId) : IRequest<Response<List<FeedbackResukt>>>
    {
        public Guid ImageId { get; set; } = imageId;
    }
}
