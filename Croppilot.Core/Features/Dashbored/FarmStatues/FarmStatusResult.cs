namespace Croppilot.Core.Features.Dashbored.FarmStatues
{
    public class FarmStatusResult
    {
        public int ActiveMachines { get; set; }
        public string IrrigationStatus { get; set; }
        public string SoilQuality { get; set; }
        public string CropHealth { get; set; }
        public string PestRisk { get; set; }
        public int WaterReservoir { get; set; }
    }
}
