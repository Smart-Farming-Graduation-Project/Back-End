using Croppilot.Core.Features.Dashbored.Equipment.Models;
using Croppilot.Core.Features.Dashbored.Equipment.Result;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Core.Features.Dashbored.Equipment
{
    public class EquipmentHandler(IEquipmentService service) : ResponseHandler,
        IRequestHandler<CreateEquipmentModel, Response<string>>,
        IRequestHandler<UpdateEquipmentModel, Response<string>>,
        IRequestHandler<DeleteEquipmentModel, Response<string>>,
        IRequestHandler<UpdateEquipmentStatusModel, Response<string>>,
    IRequestHandler<GetAllEquipmentModel, Response<IEnumerable<GetAllEquipmentResult>>>
    {
        public async Task<Response<string>> Handle(CreateEquipmentModel request, CancellationToken cancellationToken)
        {
            try
            {
                var equipment = request.Adapt<Date.Models.DashboardModels.Equipment>();
                var result = await service.CreateAsync(equipment);
                if (result is not OperationResult.Success)
                    return BadRequest<string>("Equipment creation failed");
                return Created<string>("Equipment Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(UpdateEquipmentModel request, CancellationToken cancellationToken)
        {
            try
            {
                var equipment = await service.GetByIdAsync(request.EquipmentId);
                if (equipment is null)
                    return NotFound<string>("Equipment Not Found");
                equipment = request.Adapt(equipment);
                var result = await service.UpdateAsync(equipment);
                if (result is false)
                    return NotFound<string>("Equipment Not Found");
                return Created<string>("Equipment Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }

        }

        public async Task<Response<string>> Handle(DeleteEquipmentModel request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await service.DeleteAsync(request.Id);
                if (result != true)
                    return BadRequest<string>("Equipment Is Already Exist");
                return Deleted<string>($"Equipment With Id {request.Id} Is Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }

        }

        public async Task<Response<IEnumerable<GetAllEquipmentResult>>> Handle(GetAllEquipmentModel request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await service.GetAllAsync();
                if (response is null)
                    return NotFound<IEnumerable<GetAllEquipmentResult>>("Equipment Not Found");
                var equipments = response.Select(x => new GetAllEquipmentResult(x.EquipmentId, x.Name, x.Status.ToString(), x.LastMaintenance, x.HoursUsed, x.Battery, x.Connectivity.ToString()));
                var result = Success(equipments, "Equipment fetched Successfully");
                result.Meta = new Dictionary<string, object> { { "count", response.Count() } };
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest<IEnumerable<GetAllEquipmentResult>>(ex.Message);
            }

        }

        public async Task<Response<string>> Handle(UpdateEquipmentStatusModel request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await service.UpdateEquipmentStatus(request.EquipmentId, request.Status);
                if (result is false)
                    return NotFound<string>("Equipment Not Found");
                return Success("Equipment Status Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }
        }
    }
}
