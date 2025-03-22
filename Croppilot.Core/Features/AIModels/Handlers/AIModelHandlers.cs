using Croppilot.Core.Features.AIModels.Models;
using Croppilot.Core.Features.AIModels.Results;
using Croppilot.Services.Abstract.AiSerives;

namespace Croppilot.Core.Features.AIModels.Handlers
{
    public class AIModelHandlers(IModelServices modelService) : ResponseHandler,
        IRequestHandler<PredictModelCommand, Response<ModelResults>>,
        IRequestHandler<GetFeedback, Response<List<FeedbackResukt>>>
    {
        public async Task<Response<ModelResults>> Handle(PredictModelCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await modelService.UploadPhotoToModel(request.Image);
                var modelResult = response.Adapt<ModelResults>();
                return Success(modelResult);
            }
            catch (Exception e)
            {
                return BadRequest<ModelResults>(e.Message);
            }

        }

        public async Task<Response<List<FeedbackResukt>>> Handle(GetFeedback request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await modelService.GetFeedback(request.ImageId);

                if (response == null)
                {
                    return BadRequest<List<FeedbackResukt>>("No feedback found for the given Model ID.");
                }

                var feedbackResult = response.FeedbackEntries.Select(feedback => new FeedbackResukt
                {
                    ModelId = response.ImageId.ToString(),
                    Disease = feedback.Disease,
                    Solution = feedback.Solution
                }).ToList();

                var result = Success(feedbackResult);
                result.Meta = new Dictionary<string, object>
                {
                    { "count", feedbackResult.Count }
                };
                return result;
            }
            catch (Exception e)
            {
                return BadRequest<List<FeedbackResukt>>(e.Message);
            }
        }
    }
}
