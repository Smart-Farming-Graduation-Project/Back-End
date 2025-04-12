using Croppilot.Date.Helpers.Dashboard;

namespace Croppilot.Services.Abstract.DashboredServices
{
    public interface IFarmStatusService
    {
        Task<SoilQualityReport> GetSoilQualityReportAsync(double latitude, double longitude);
        Task<FarmStatusDto> GetFarmStatus();
    }
}
