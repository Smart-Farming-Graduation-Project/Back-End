using Croppilot.Core.Features.Dashbored.Alerts.Models;
using Croppilot.Core.Features.Dashbored.Alerts.Result;
using Croppilot.Date.Models.DashboardModels;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Core.Features.Dashbored.Alerts
{
    public class AlertHandlers(IAlertsServices service) : ResponseHandler,
        IRequestHandler<GetAllAlerts, Response<IEnumerable<GetAllAlertsResponse>>>,
        IRequestHandler<CreateAlert, Response<string>>
    {
        public async Task<Response<IEnumerable<GetAllAlertsResponse>>> Handle(GetAllAlerts request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await service.GetAllAsync();
                if (response is null)
                    return NotFound<IEnumerable<GetAllAlertsResponse>>("Alerts Not Found");
                var alerts = response.Select(x =>
                    new GetAllAlertsResponse(x.Id, x.EmergencyType.ToString(),
                        x.Message, x.Severity.ToString(), x.Latitude, x.Longitude, x.LocationDescription, x.CreatedAt));

                var result = Success(alerts, "Alerts fetched Successfully");
                result.Meta = new Dictionary<string, object> { { "count", response.Count() } };
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest<IEnumerable<GetAllAlertsResponse>>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(CreateAlert request, CancellationToken cancellationToken)
        {
            try
            {
                var alert = request.Adapt<Alert>();
                var result = await service.CreateAsync(alert);

                if (result is not OperationResult.Success)
                    return BadRequest<string>("Alert creation failed");

                return Created<string>("Alert Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }
        }
    }
}
