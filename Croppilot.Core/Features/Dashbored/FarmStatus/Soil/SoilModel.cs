using Croppilot.Date.Helpers.Dashboard;

namespace Croppilot.Core.Features.Dashbored.FarmStatus.Soil
{
    public class SoilModel(double latitude, double Longitude) : IRequest<Response<SoilQualityReport>>
    {
        public double Latitude { get; set; } = latitude;
        public double Longitude { get; set; } = Longitude;
    }
}
