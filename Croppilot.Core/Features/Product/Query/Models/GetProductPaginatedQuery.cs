namespace Croppilot.Core.Features.Product.Query.Models;

public class GetProductPaginatedQuery : IRequest<Response<List<GetProductPaginatedResponse>>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public ProductOrderingEnum OrderBy { get; set; } = ProductOrderingEnum.Availability;
    public string? Search { get; set; } = null;
}