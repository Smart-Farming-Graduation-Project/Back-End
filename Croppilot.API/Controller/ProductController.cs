using Croppilot.API.Bases;
using Croppilot.Core.Featuers.Product.Command.Models;
using Croppilot.Core.Featuers.Product.Query.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller
{
    public class ProductController(IMediator mediator) : AppControllerBase
    {
        [HttpGet("ProductsList")]
        public async Task<IActionResult> GetProducts()
        {
            var response = await mediator.Send(new GetAllProductQuery());
            return Ok(response);
        }
        [HttpGet("paginatedList")]
        public async Task<IActionResult> Paginated([FromQuery] GetProductPaginatedQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var response = await mediator.Send(new GetProductByIdQueryy(id));
            return NewResult(response);
        }
        [HttpPost("Product/Create")]
        public async Task<IActionResult> Create(/*[FromBody]*/ AddProductCommand command)
        {
            var response = await mediator.Send(command);
            return NewResult(response);
        }
        //[HttpPut("Product/Update")]
        //public async Task<IActionResult> Edit([FromBody] EditProductCommand command)
        //{
        //    var response = await mediator.Send(command);
        //    return NewResult(response);
        //}
        [HttpDelete("ProductDelete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await mediator.Send(new DeleteProductCommand(id));
            return NewResult(response);
        }
    }
}
