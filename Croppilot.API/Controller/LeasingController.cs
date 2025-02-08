using Croppilot.API.Bases;
using Croppilot.Core.Features.Leasing.Query.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller
{

    public class LeasingController(IMediator mediator) : AppControllerBase
    {
        //[HttpPost("lease")]
        //public async Task<IActionResult> LeaseProduct([FromBody] LeaseProductCommand command)
        //{
        //    var result = await mediator.Send(command);
        //    return Ok(result);
        //}

        //[HttpPost("end/{id}")]
        //public async Task<IActionResult> EndLease(int id, [FromBody] DateTime endDate)
        //{
        //    var result = await mediator.Send(new EndLeaseCommand(id, endDate));
        //    return result == null ? NotFound() : Ok(result);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLeasingById(int id)
        {
            var response = await mediator.Send(new GetLeasingByIdQuery(id));
            return NewResult(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllLeasing()
        {
            var result = await mediator.Send(new GetAllLeasingsQuery());
            return NewResult(result);
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetLeasingByProductId(int productId)
        {
            var result = await mediator.Send(new GetLeasingsByProductIdQuery(productId));
            return NewResult(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetActiveLeases(int userId)
        {
            var result = await mediator.Send(new GetActiveLeasesQuery());
            return NewResult(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteLeasing(int id)
        //{
        //    var result = await mediator.Send(new DeleteLeaseCommand(id));
        //    return result ? Ok() : NotFound();
        //}
    }
}
