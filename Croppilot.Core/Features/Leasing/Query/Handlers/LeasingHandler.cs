using Croppilot.Core.Features.Leasing.Query.Models;
using Croppilot.Core.Features.Leasing.Query.Result;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Leasing.Query.Handlers
{
    public class LeasingHandler(ILeasingService leasingService) : ResponseHandler,
    IRequestHandler<GetAllLeasingsQuery, Response<IEnumerable<GetAllLeasingResult>>>,
    IRequestHandler<GetLeasingsByProductIdQuery, Response<GetAllActiveLeasingResult>>,
    IRequestHandler<GetLeasingByIdQuery, Response<GetAllActiveLeasingResult?>>,
    IRequestHandler<GetActiveLeasesQuery, Response<IEnumerable<GetAllActiveLeasingResult>>>
    {
        public async Task<Response<IEnumerable<GetAllLeasingResult>>> Handle(GetAllLeasingsQuery request, CancellationToken cancellationToken)
        {
            var productList = await leasingService.GetAllLeasingsAsync();

            var productResult = productList.Adapt<IEnumerable<GetAllLeasingResult>>();

            var result = Success(productResult);
            result.Meta = new Dictionary<string, object> { { "count", productResult.Count() } };

            return result;
        }

        public async Task<Response<GetAllActiveLeasingResult>> Handle(GetLeasingsByProductIdQuery request, CancellationToken cancellationToken)
        {
            var product = await leasingService.GetLeasingsByProductIdAsync(request.ProductId);
            if (product is null)
                return NotFound<GetAllActiveLeasingResult>("This Product Is Not Found");

            var Result = product.Adapt<GetAllActiveLeasingResult>();

            return Success(Result);
        }

        public async Task<Response<GetAllActiveLeasingResult?>> Handle(GetLeasingByIdQuery request, CancellationToken cancellationToken)
        {
            var lease = await leasingService.GetLeasingByIdAsync(request.Id);
            if (lease is null)
                return NotFound<GetAllActiveLeasingResult>("Leasing record not found");

            var Result = lease.Adapt<GetAllActiveLeasingResult>();

            return Success(Result);
        }

        public async Task<Response<IEnumerable<GetAllActiveLeasingResult>>> Handle(GetActiveLeasesQuery request, CancellationToken cancellationToken)
        {
            var activeLeases = await leasingService.GetActiveLeasesAsync();
            if (activeLeases is null)
                return NotFound<IEnumerable<GetAllActiveLeasingResult>>("No active leases found");

            var Result = activeLeases.Adapt<IEnumerable<GetAllActiveLeasingResult>>();

            return Success(Result);
        }
    }
}
