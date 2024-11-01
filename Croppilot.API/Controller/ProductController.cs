using Croppilot.API.Bases;
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
    }
}
