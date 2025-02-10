namespace Croppilot.Core.Features.Orders.Query.Models;

public class GetOrderByIdQuery : IRequest<Response<GetOrderResponse>>
{
    public int OrderId { get; set; }
}