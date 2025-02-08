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
            return result switch
            {
                OperationResult.Success => Created("Leasing Product added successfully."),
                OperationResult.NotFound => NotFound<string>("Product not found."),
                OperationResult.NotAvailable => BadRequest<string>("Product is not available for leasing."),
                OperationResult.AlreadyLeased => Conflict<string>("Product is already leased."),
                OperationResult.InvalidDate => BadRequest<string>("Invalid leasing period."),
                _ => BadRequest<string>("Leasing Product creation failed.")
            };

        }

        public async Task<Response<string>> Handle(EndLeaseCommand request, CancellationToken cancellationToken)
        {
            var result =
                await leasingService.EndLeaseAsync(request.Id);
            return result switch
            {
                OperationResult.Success => Success($"Leasing Product {request.Id} ended successfully."),
                OperationResult.NotFound => NotFound<string>("Leasing Product not found."),
                OperationResult.AlreadyEnded => Conflict<string>("Leasing has already ended."),
                _ => BadRequest<string>("Leasing Product end failed.")
            };
        }

        public async Task<Response<string>> Handle(DeleteLeaseCommand request, CancellationToken cancellationToken)
        {
            var result =
                await leasingService.DeleteLeasingAsync(request.Id);
            return result switch
            {
                OperationResult.Success => Deleted<string>($"Leasing Product {request.Id} deleted successfully."),
                OperationResult.NotFound => NotFound<string>("Leasing Product not found."),
                _ => BadRequest<string>("Leasing Product deletion failed.")
            };
        }
    }
}
