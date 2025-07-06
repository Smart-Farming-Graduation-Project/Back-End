using Croppilot.Core.Features.Product.Query.Result;

namespace Croppilot.Core.Features.Product.Query.Models;

public class GetProductsByUserIdQuery : IRequest<Response<List<GetAllProductResponse>>>
{
    public string UserId { get; set; } = null!;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public ProductOrderingEnum OrderBy { get; set; } = ProductOrderingEnum.CreatedAt;
    public string? Search { get; set; } = null;
} 