using Croppilot.Core.Features.Leasing.Query.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Leasing.Query.Handlers
{
    public class LeasingHandler(ILeasingService leasingService) : ResponseHandler,
    IRequestHandler<GetAllLeasingsQuery, Response<IEnumerable<Date.Models.Leasing>>>,
    IRequestHandler<GetLeasingsByProductIdQuery, Response<IEnumerable<Date.Models.Leasing>>>,
    IRequestHandler<GetLeasingByIdQuery, Response<Date.Models.Leasing?>>,
    IRequestHandler<GetActiveLeasesQuery, Response<IEnumerable<Date.Models.Leasing>>>
    {
        public async Task<Response<IEnumerable<Date.Models.Leasing>>> Handle(GetAllLeasingsQuery request, CancellationToken cancellationToken)
        {
            var productList = await leasingService.GetAllLeasingsAsync();

            var productResult = productList.Adapt<IEnumerable<Date.Models.Leasing>>();

            var result = Success(productResult);
            result.Meta = new Dictionary<string, object> { { "count", productResult.Count() } };

            return result;
        }

        public async Task<Response<IEnumerable<Date.Models.Leasing>>> Handle(GetLeasingsByProductIdQuery request, CancellationToken cancellationToken)
        {
            var product = await leasingService.GetLeasingsByProductIdAsync(request.ProductId);
            if (product is null)
                return NotFound<IEnumerable<Date.Models.Leasing>>("This Product Is Not Found");

            var Result = product.Adapt<IEnumerable<Date.Models.Leasing>>();

            return Success(Result);
        }

        public async Task<Response<Date.Models.Leasing?>> Handle(GetLeasingByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await leasingService.GetLeasingByIdAsync(request.Id);
            if (product is null)
                return NotFound<Date.Models.Leasing>("This Product Is Not Found");

            var Result = product.Adapt<Date.Models.Leasing>();

            return Success(Result);
        }

        public async Task<Response<IEnumerable<Date.Models.Leasing>>> Handle(GetActiveLeasesQuery request, CancellationToken cancellationToken)
        {
            var product = await leasingService.GetActiveLeasesAsync();
            if (product is null)
                return NotFound<IEnumerable<Date.Models.Leasing>>("This Product Is Not Found");

            var Result = product.Adapt<IEnumerable<Date.Models.Leasing>>();

            return Success(Result);
        }
    }
}
