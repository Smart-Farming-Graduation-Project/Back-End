using Croppilot.Date.Helpers;

namespace Croppilot.Services.Abstract.AiSerives
{
    public interface IRlPredictServices
    {
        Task<int> PredictAction(SmartFarmObservation observation);
        Task<SmartFarmObservation> GetDefaultValue();
    }
}
