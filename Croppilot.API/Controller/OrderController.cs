using Croppilot.Core.Features.Orders.Command.Models;
using Croppilot.Core.Features.Orders.Query.Models;

namespace Croppilot.API.Controller;

public class OrderController(IMediator mediator) : AppControllerBase
{
    [HttpGet("OrdersList")]
    // [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
    public async Task<IActionResult> GetOrders()
    {
        var response = await mediator.Send(new GetAllOrdersQuery());
        return NewResult(response);
    }

    [HttpGet("{id}")]
    // [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
    public async Task<IActionResult> GetOrderById([FromRoute] int id)
    {
        var response = await mediator.Send(new GetOrderByIdQuery { OrderId = id });
        return NewResult(response);
    }

    [HttpGet("user/{userId}")]
    // [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
    public async Task<IActionResult> GetUserOrders([FromRoute] string userId)
    {
        /* todo : Fix later :
         Issue: The current implementation allows users to manipulate other users' carts by specifying any UserId in requests
        Remove UserId from end point and request body.
        Instead, retrieve the authenticated user's ID from the request context (JWT claims).
        Modify the controller to infer UserId from the authenticated user:
        // Example using HttpContext.User
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    */

        var response = await mediator.Send(new GetUserOrdersQuery { UserId = userId });
        return NewResult(response);
    }

    [HttpPost("Create")]
    // [EnableRateLimiting(RateLimiters.PaymentEndpointsLimit)]
    public async Task<IActionResult> Create(CreateOrderCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Update")]
    // [EnableRateLimiting(RateLimiters.PaymentEndpointsLimit)]
    public async Task<IActionResult> Update(UpdateOrderCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("Delete/{id}")]
    // [EnableRateLimiting(RateLimiters.PaymentEndpointsLimit)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await mediator.Send(new DeleteOrderCommand(id));
        return NewResult(response);
    }
}