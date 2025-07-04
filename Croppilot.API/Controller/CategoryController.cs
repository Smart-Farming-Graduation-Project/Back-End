﻿using Croppilot.Core.Attributes;
using Croppilot.Core.Features.Category.Command.Models;
using Croppilot.Core.Features.Category.Query.Models;


namespace Croppilot.API.Controller;

//[Authorize(Policy = nameof(UserRoleEnum.User))]
public class CategoryController(IMediator mediator) : AppControllerBase
{
	    [HttpGet("CategoryList")]
	// [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
	[Cache(timeToLiveSeconds: 3600)] // Cache for 1 hour
	public async Task<IActionResult> GetAllCategory()
	{
		var response = await mediator.Send(new GetAllCategoryQuery());
		return NewResult(response);
	}

	    [HttpGet("CategoryPaginatedList")]
	// [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
	[Cache(timeToLiveSeconds: 1800)] // Cache for 30 minutes
	public async Task<IActionResult> Paginated([FromQuery] GetCategoryPaginatedQuery query)
	{
		var response = await mediator.Send(query);
		return NewResult(response);
	}

	    [HttpGet("Category/{id}")]
	// [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
	[Cache(timeToLiveSeconds: 3600)] // Cache for 1 hour
	public async Task<IActionResult> GetCategoryById([FromRoute] int id)
	{
		var response = await mediator.Send(new GetCategoryByIdQuery(id));
		return NewResult(response);
	}

	[HttpPost("Category/Create")]
	// [EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
	[SwaggerOperation(Summary = "Create a new category",
		Description = "Create a new category with the provided details. Only JPEG and PNG formats are allowed")]
	[CacheInvalidate("category", "product")]
	public async Task<IActionResult> Create( /*[FromBody]*/ AddCategoryCommand command)
	{
		var response = await mediator.Send(command);
		return NewResult(response);
	}

	[HttpPut("Category/Update")]
	// [EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
	[SwaggerOperation(Summary = "Update an existing category",
		Description = "Update an existing category with the provided details. Only JPEG and PNG formats are allowed")]
	[CacheInvalidate("category", "product")]
	public async Task<IActionResult> Edit( /*[FromBody]*/ EditCategoryCommand command)
	{
		var response = await mediator.Send(command);
		return NewResult(response);
	}

	[HttpDelete("CategoryDelete/{id}")]
	// [EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
	public async Task<IActionResult> Delete([FromRoute] int id)
	{
		var response = await mediator.Send(new DeleteCategoryCommand(id));
		return NewResult(response);
	}
}