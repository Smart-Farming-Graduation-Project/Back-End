using Croppilot.Core.Features.AIModels.Models;
using Croppilot.Core.Features.AIModels.Results;
using Croppilot.Date.Helpers;
using Croppilot.Services.Abstract.AiSerives;

namespace Croppilot.Core.Features.AIModels.Handlers
{
    public class AIModelHandlers(IModelServices modelService, IRlPredictServices rlServices) : ResponseHandler,
        IRequestHandler<PredictModelCommand, Response<ModelResults>>,
        IRequestHandler<GetFeedback, Response<List<FeedbackResukt>>>,
        IRequestHandler<GetWateringFeedback, Response<PredictionResponse>>,
        IRequestHandler<GetCurrentValue, Response<CurrentValueResponse>>
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

        public async Task<Response<PredictionResponse>> Handle(GetWateringFeedback request, CancellationToken cancellationToken)
        {
            try
            {
                bool isArabic = request.language?.StartsWith("ar", StringComparison.OrdinalIgnoreCase) ?? false;
                var command = request.Adapt<SmartFarmObservation>();

                int action = await rlServices.PredictAction(command);

                var (decision, message) = GetDecisionMessage(action, isArabic);
                return Success(new PredictionResponse
                {
                    Action = action,
                    Decision = decision,
                    Message = message,
                    Language = isArabic ? "ar" : "en"
                });
            }
            catch (Exception ex)
            {
                bool isArabic = request.language.StartsWith("ar");
                var errorMessage = isArabic
                    ? $"خطأ في التنبؤ: {ex.Message}"
                    : $"Error making prediction: {ex.Message}";

                return BadRequest<PredictionResponse>(errorMessage);
            }
        }




        private (string decision, string message) GetDecisionMessage(int action, bool isArabic)
        {
            return action switch
            {
                0 => isArabic
                    ? ("لا تسقي", "لا يلزم الري حالياً، حالة التربة جيدة")
                    : ("No watering", "No watering needed now, soil condition is good"),

                1 => isArabic
                    ? ("سقي قليل", "الري الخفيف مطلوب لتحسين رطوبة التربة")
                    : ("Light watering", "Light watering needed to improve soil moisture"),

                2 => isArabic
                    ? ("سقي متوسط", "الري المعتدل مطلوب للنمو الأمثل")
                    : ("Moderate watering", "Moderate watering needed for optimal growth"),

                3 => isArabic
                    ? ("سقي كثير", "الري الغزير مطلوب بسبب جفاف التربة")
                    : ("Heavy watering", "Heavy watering needed due to dry soil"),

                _ => isArabic
                    ? ("إجراء غير معروف", "تعذر تحديد إجراء الري المناسب")
                    : ("Unknown action", "Could not determine appropriate watering action")
            };
        }

        public async Task<Response<CurrentValueResponse>> Handle(GetCurrentValue request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await rlServices.GetDefaultValue();
                var modelResult = response.Adapt<CurrentValueResponse>();
                return Success(modelResult);
            }
            catch (Exception e)
            {
                return BadRequest<CurrentValueResponse>(e.Message);
            }
        }
    }

}
