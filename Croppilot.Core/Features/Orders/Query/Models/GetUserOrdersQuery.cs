namespace Croppilot.Core.Features.Orders.Query.Models;

public class GetUserOrdersQuery : IRequest<Response<List<GetOrderResponse>>>
{
    public string UserId { get; set; }
}