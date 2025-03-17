namespace Croppilot.Core.Features.CosmosDb.Result
{
    public class GetIotDataResult
    {
        public string Id { get; set; }

        public string DeviceId { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
