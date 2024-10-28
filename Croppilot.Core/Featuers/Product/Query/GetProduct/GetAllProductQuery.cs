using Croppilot.Infrastructure.Comman;
using MediatR;

namespace Croppilot.Core.Featuers.Product.Query.GetProduct
{
    public class GetAllProductQuery(PaginationRequest PaginationRequest)
        : IRequest<Date.Models.Product>;

    public record GetOrdersResult(PaginatedResult<ProductResponse> Products);

}
