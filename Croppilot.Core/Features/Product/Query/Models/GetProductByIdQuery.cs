using Croppilot.Core.Features.Product.Query.Result;

namespace Croppilot.Core.Features.Product.Query.Models;

public class GetProductByIdQuery(int id) : IRequest<Response<GetProductByIdResponse>>
{
    public int Id { get; set; } = id;
}