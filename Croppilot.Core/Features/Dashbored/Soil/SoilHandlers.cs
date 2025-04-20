using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Core.Features.Dashbored.Soil
{
    public class SoilHandlers(ISoilServices service) : ResponseHandler,
        IRequestHandler<SoilMoistureModel, Response<IEnumerable<SoilResult>>>
    {
        public async Task<Response<IEnumerable<SoilResult>>> Handle(SoilMoistureModel request, CancellationToken cancellationToken)
        {
            var soil = await service.GetAll();
            if (soil is null)
                return NotFound<IEnumerable<SoilResult>>("Soil Not Found");
            var response = soil.Adapt<IEnumerable<SoilResult>>();
            var result = Success(response, "Soil fetched successfully!");
            result.Meta = new Dictionary<string, object> { { "count", response.Count() } };
            return result;
        }
    }
}
