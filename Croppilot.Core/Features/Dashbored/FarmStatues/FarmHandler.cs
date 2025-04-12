using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Core.Features.Dashbored.FarmStatues
{
    public class FarmHandler(IFarmStatusService service) : ResponseHandler,
        IRequestHandler<GetFarmStatusModel, Response<FarmStatusResult>>
    {
        public async Task<Response<FarmStatusResult>> Handle(GetFarmStatusModel request, CancellationToken cancellationToken)
        {
            try
            {
                var status = await service.GetFarmStatus();
                var result = status.Adapt<FarmStatusResult>();
                if (status is null)
                    return NotFound<FarmStatusResult>("Farm Status Not Found");
                return Created<FarmStatusResult>(result, "Farm Status Retrieved Successfully");
            }
            catch (Exception e)
            {
                return BadRequest<FarmStatusResult>(e.Message);
            }
        }
    }
}
