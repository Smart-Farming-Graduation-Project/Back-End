using Croppilot.Core.Featuers.Product.Query.Result;
using Croppilot.Date.Enum;
using Croppilot.Infrastructure.Comman;
using MediatR;

namespace Croppilot.Core.Featuers.Product.Query.Models
{
    public class GetProductPaginatedQuery : IRequest<PaginatedResult<GetProductPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ProductOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
