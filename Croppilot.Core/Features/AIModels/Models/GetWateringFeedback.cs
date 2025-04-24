using Croppilot.Core.Features.AIModels.Results;

namespace Croppilot.Core.Features.AIModels.Models
{
    public class GetWateringFeedback : IRequest<Response<PredictionResponse>>
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double SoilMoisture { get; set; }
        public double Growth { get; set; }
        public float FertilizerLevel { get; set; }
        public double Sunlight { get; set; }
        public string? language { get; set; }
    }
}
