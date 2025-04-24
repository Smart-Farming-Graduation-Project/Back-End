namespace Croppilot.Core.Features.AIModels.Results
{
    public class CurrentValueResponse
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double SoilMoisture { get; set; }
        public double Growth { get; set; }
        public float FertilizerLevel { get; set; }
        public double Sunlight { get; set; }
    }
}
