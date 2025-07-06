using Croppilot.Core.Features.Product.Query.Result;

namespace Croppilot.Core.Features.Product.Query.Models;

public class GetProductsByUserIdQuery : IRequest<Response<List<GetAllProductResponse>>>
{
    public string UserId { get; set; } = null!;
} 