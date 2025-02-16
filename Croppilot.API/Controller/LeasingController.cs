using Croppilot.Core.Features.Leasing.Command.Model;
using Croppilot.Core.Features.Leasing.Query.Models;


namespace Croppilot.API.Controller;

public class LeasingController(IMediator mediator) : AppControllerBase
{
    [HttpPost("MakeLease")]
    public async Task<IActionResult> LeaseProduct([FromBody] LeaseProductCommand command)
    {
        var result = await mediator.Send(command);
        return NewResult(result);
    }


    [HttpPost("EndLease/{id}")]
    public async Task<IActionResult> EndLease(int id, [FromBody] DateTime endDate)
    {
        var result = await mediator.Send(new EndLeaseCommand(id, endDate));
        return NewResult(result);
    }

    [HttpGet("GetLeasingById/{id}")]
    public async Task<IActionResult> GetLeasingById(int id)
    {
        var response = await mediator.Send(new GetLeasingByIdQuery(id));
        return NewResult(response);
    }


    [HttpGet("GetAllLeasing")]
    public async Task<IActionResult> GetAllLeasing()
    {
        var result = await mediator.Send(new GetAllLeasingsQuery());
        return Ok(result);
    }

    [HttpGet("GetLeasingByProductId/{productId}")]
    public async Task<IActionResult> GetLeasingByProductId(int productId)
    {
        var result = await mediator.Send(new GetLeasingsByProductIdQuery(productId));
        return NewResult(result);
    }

    [HttpGet("GetActiveLeases")]
    public async Task<IActionResult> GetActiveLeases()
    {
        var result = await mediator.Send(new GetActiveLeasesQuery());
        return NewResult(result);
    }

    [HttpDelete("DeleteLeasing/{id}")]
    public async Task<IActionResult> DeleteLeasing(int id)
    {
        var result = await mediator.Send(new DeleteLeaseCommand(id));
        return NewResult(result);
    }
}