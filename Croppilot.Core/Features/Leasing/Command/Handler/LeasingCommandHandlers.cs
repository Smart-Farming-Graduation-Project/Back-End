using Croppilot.Core.Features.Leasing.Command.Model;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Leasing.Command.Handler
{
    public class LeasingCommandHandlers(ILeasingService leasingService) : ResponseHandler,
        IRequestHandler<LeaseProductCommand, Response<string>>,
        IRequestHandler<EndLeaseCommand, Response<string>>,
        IRequestHandler<DeleteLeaseCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(LeaseProductCommand request, CancellationToken cancellationToken)
        {
            var result =
                await leasingService.LeaseProductAsync(request.ProductId, request.StartingDate, request.EndDate, request.LeasingDetails);
            return result is OperationResult.Success
                ? Created("Leasing Product Added Successfully")
                : BadRequest<string>("Leasing Product creation failed");
        }

        public async Task<Response<string>> Handle(EndLeaseCommand request, CancellationToken cancellationToken)
        {
            var result =
                await leasingService.EndLeaseAsync(request.Id);
            return result is OperationResult.Success
                ? Created($"Leasing Product{request.Id} End Successfully")
                : BadRequest<string>("Leasing Product End failed");
        }

        public async Task<Response<string>> Handle(DeleteLeaseCommand request, CancellationToken cancellationToken)
        {
            var result =
                await leasingService.DeleteLeasingAsync(request.Id);
            return result is OperationResult.Success
                ? Deleted<string>($"Product {request.Id} Deleted Successfully")
                : BadRequest<string>("Deletion failed");
        }
    }
}
