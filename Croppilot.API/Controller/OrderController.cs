using Croppilot.API.Bases;
using Croppilot.Core.Features.Orders.Command.Models;
using Croppilot.Core.Features.Orders.Query.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller;

public class OrderController(IMediator mediator) : AppControllerBase
{

    [HttpGet("OrdersList")]
    public async Task<IActionResult> GetOrders()
    {
        var response = await mediator.Send(new GetAllOrdersQuery());
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById([FromRoute] int id)
    {
        var response = await mediator.Send(new GetOrderByIdQuery { OrderId = id });
        return NewResult(response);
    }
    
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserOrders([FromRoute] string userId)
    {
        var response = await mediator.Send(new GetUserOrdersQuery { UserId = userId });
        return NewResult(response);
    }
    
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateOrderCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }
    
    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateOrderCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }
    
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await mediator.Send(new DeleteOrderCommand(id));
        return NewResult(response);
    }
}