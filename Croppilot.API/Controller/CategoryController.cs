using Croppilot.Core.Features.Category.Command.Models;
using Croppilot.Core.Features.Category.Query.Models;


namespace Croppilot.API.Controller;

[Authorize(Policy = nameof(UserRoleEnum.User))]
public class CategoryController(IMediator mediator) : AppControllerBase
{
    [ResponseCache(CacheProfileName = "Default")]
    [HttpGet("CategoryList")]
    public async Task<IActionResult> GetAllCategory()
    {
        var response = await mediator.Send(new GetAllCategoryQuery());
        return Ok(response);
    }
    [ResponseCache(CacheProfileName = "Default")]
    [HttpGet("CategoryPaginatedList")]
    public async Task<IActionResult> Paginated([FromQuery] GetCategoryPaginatedQuery query)
    {
        var response = await mediator.Send(query);
        return Ok(response);
    }
    [ResponseCache(CacheProfileName = "Default")]
    [HttpGet("Category/{id}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] int id)
    {
        var response = await mediator.Send(new GetCategoryByIdQuery(id));
        return NewResult(response);
    }

    [HttpPost("Category/Create")]
    public async Task<IActionResult> Create( /*[FromBody]*/ AddCategoryCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Category/Update")]
    public async Task<IActionResult> Edit( /*[FromBody]*/ EditCategoryCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("CategoryDelete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await mediator.Send(new DeleteCategoryCommand(id));
        return NewResult(response);
    }
}