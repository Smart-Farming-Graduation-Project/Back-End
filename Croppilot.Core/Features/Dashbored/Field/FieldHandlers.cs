using Croppilot.Core.Features.Dashbored.Field.Models;
using Croppilot.Core.Features.Dashbored.Field.Results;
using Croppilot.Services.Abstract.DashboredServices;

namespace Croppilot.Core.Features.Dashbored.Field
{
    public class FieldHandlers(IFieldService service) : ResponseHandler,
            IRequestHandler<CreateFieldModel, Response<string>>,
            IRequestHandler<UpdateFieldModel, Response<string>>,
            IRequestHandler<DeleteFieldModel, Response<string>>,
            IRequestHandler<GetFieldById, Response<GetFieldByIdResult>>,
            IRequestHandler<GetAllFieldModel, Response<IEnumerable<GetAllFieldResults>>>
    {
        public async Task<Response<string>> Handle(CreateFieldModel request, CancellationToken cancellationToken)
        {
            try
            {
                var field = request.Adapt<Date.Models.DashboardModels.Field>();
                var result = await service.CreateAsync(field);
                if (result is not OperationResult.Success)
                    return BadRequest<string>("Field creation failed");
                return Created<string>("Field Added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(DeleteFieldModel request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await service.DeleteAsync(request.Id);

                if (result != true)
                    return BadRequest<string>("Field Is Already Exist");

                return Deleted<string>($"Field With Id {request.Id} Is Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);
            }
        }

        public async Task<Response<string>> Handle(UpdateFieldModel request, CancellationToken cancellationToken)
        {
            try
            {
                var field = await service.GetByIdAsync(request.Id);

                if (field is null)
                    return NotFound<string>("Field Not Found");
                field = request.Adapt(field);
                var result = await service.UpdateAsync(field);
                if (result is false)
                    return NotFound<string>("Field Not Found");
                return Created<string>("Field Updated Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest<string>(ex.Message);

            }
        }


        //Query Handler
        public async Task<Response<GetFieldByIdResult>> Handle(GetFieldById request, CancellationToken cancellationToken)
        {
            var field = await service.GetByIdAsync(request.Id);
            if (field is null)
                return NotFound<GetFieldByIdResult>("Field Not Found");
            return Success(new GetFieldByIdResult(field.Id, field.Name, field.Size, field.Crop, field.PlantingDate, field.HarvestDate, field.Irrigation.ToString(), field.Status.ToString())
                , $"Field With Id {request.Id} fetched Successfully");

        }

        public async Task<Response<IEnumerable<GetAllFieldResults>>> Handle(GetAllFieldModel request, CancellationToken cancellationToken)
        {
            var fields = await service.GetAllAsync();
            if (fields is null)
                return NotFound<IEnumerable<GetAllFieldResults>>("Field Not Found");
            var response = fields.Select(f => new GetAllFieldResults(f.Id, f.Name, f.Size, f.Crop, f.PlantingDate, f.HarvestDate, f.Irrigation.ToString(), f.Status.ToString()));
            var result = Success(response, "Field fetched successfully!");
            result.Meta = new Dictionary<string, object> { { "count", response.Count() } };
            return result;

        }

    }
}
