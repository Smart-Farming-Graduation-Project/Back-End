namespace Croppilot.Core.Features.AIModels.Results
{
    public class PredictionResponse
    {
        public int Action { get; set; }
        public string Decision { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
    }
}
