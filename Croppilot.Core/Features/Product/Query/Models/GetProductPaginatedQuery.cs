using Croppilot.Core.Features.Product.Query.Result;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.Core.Features.Product.Query.Models;

public class GetProductPaginatedQuery : IRequest<PaginatedResult<GetProductPaginatedResponse>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public ProductOrderingEnum OrderBy { get; set; } = ProductOrderingEnum.Availability;
    public string? Search { get; set; } = null;
}