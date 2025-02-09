using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Orders.Query.Handlers;

public class OrderQueryHandler(
    IOrderService orderService
) : ResponseHandler,
    IRequestHandler<GetAllOrdersQuery, Response<List<GetOrderResponse>>>,
    IRequestHandler<GetOrderByIdQuery, Response<GetOrderResponse>>,
    IRequestHandler<GetUserOrdersQuery, Response<List<GetOrderResponse>>>
{
    public async Task<Response<List<GetOrderResponse>>> Handle(GetAllOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await orderService.GetAllAsync(includeProperties: ["OrderItems"],
            cancellationToken: cancellationToken);
        
        var orderResponses = orders.Adapt<List<GetOrderResponse>>();
        
        var response = Success(orderResponses);
        response.Meta = new Dictionary<string, object> { { "count", orderResponses.Count } };
        return response;
    }

    public async Task<Response<GetOrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await orderService.GetByIdAsync(request.OrderId, includeProperties: ["OrderItems"],
            cancellationToken: cancellationToken);
        
        if (order == null)
            return NotFound<GetOrderResponse>("Order not found");

        var orderResponse = order.Adapt<GetOrderResponse>();
        
        return Success(orderResponse);
    }

    public async Task<Response<List<GetOrderResponse>>> Handle(GetUserOrdersQuery request,
        CancellationToken cancellationToken)
    {
        var orders = await orderService.GetUserOrdersAsync(request.UserId, cancellationToken: cancellationToken);
        var orderResponses = orders.Adapt<List<GetOrderResponse>>();
        var response = Success(orderResponses);
        response.Meta = new Dictionary<string, object> { { "count", orderResponses.Count } };
        return response;
    }
}