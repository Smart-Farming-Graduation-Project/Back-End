using Croppilot.Date.Models;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class TestController(IProductServices _productServices)
    : ControllerBase
{
    [HttpGet("ProductList")]
    public async Task<IActionResult> GetProduct()
    {
        var products = await _productServices.GetAll(includeProperties:"Category", cancellationToken: default);
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> GetProductById(int id, string? includeProperties = null, CancellationToken cancellationToken = default)
    {
        var product = await _productServices.GetById(id, includeProperties, cancellationToken);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}