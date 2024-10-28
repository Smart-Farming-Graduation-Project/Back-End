using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Croppilot.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(IProductServices services) : ControllerBase
    {
        [HttpGet("ProductList")]
        public async Task<IActionResult> GetProduct()
        {
            var products = await services.GetAllProduct(includeProp: "Category");
            return Ok(products);
        }
    }
}
