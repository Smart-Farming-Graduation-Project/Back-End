using Croppilot.Core.Features.Category.Command.Models;
using Croppilot.Core.Features.Category.Query.Models;


namespace Croppilot.API.Controller;

[Authorize(Policy = nameof(UserRoleEnum.User))]
public class CategoryController(IMediator mediator) : AppControllerBase
{
    [ResponseCache(CacheProfileName = "Default"), HttpGet("CategoryList")]
    [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
    public async Task<IActionResult> GetAllCategory()
    {
        var response = await mediator.Send(new GetAllCategoryQuery());
        return NewResult(response);
    }

    [ResponseCache(CacheProfileName = "Default"), HttpGet("CategoryPaginatedList")]
    [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
    public async Task<IActionResult> Paginated([FromQuery] GetCategoryPaginatedQuery query)
    {
        var response = await mediator.Send(query);
        return NewResult(response);
    }

    [ResponseCache(CacheProfileName = "Default"), HttpGet("Category/{id}")]
    [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
    public async Task<IActionResult> GetCategoryById([FromRoute] int id)
    {
        var response = await mediator.Send(new GetCategoryByIdQuery(id));
        return NewResult(response);
    }

    [HttpPost("Category/Create")]
    [EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
    public async Task<IActionResult> Create( /*[FromBody]*/ AddCategoryCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut("Category/Update")]
    [EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
    public async Task<IActionResult> Edit( /*[FromBody]*/ EditCategoryCommand command)
    {
        var response = await mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete("CategoryDelete/{id}")]
    [EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var response = await mediator.Send(new DeleteCategoryCommand(id));
        return NewResult(response);
    }
}