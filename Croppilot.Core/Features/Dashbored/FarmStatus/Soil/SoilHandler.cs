using Croppilot.Date.Helpers.Dashboard;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Core.Features.Dashbored.FarmStatus.Soil
{
    public class SoilHandler(IFarmStatusService farmStatusService) : ResponseHandler,
      IRequestHandler<SoilModel, Response<SoilQualityReport>>
    {
        public async Task<Response<SoilQualityReport>> Handle(SoilModel request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await farmStatusService.GetSoilQualityReportAsync(request.Latitude, request.Longitude);
                return Success(result, "Soil quality report fetched successfully!");

            }
            catch (Exception ex)
            {
                return BadRequest<SoilQualityReport>(ex.Message);
            }
        }
    }
}
