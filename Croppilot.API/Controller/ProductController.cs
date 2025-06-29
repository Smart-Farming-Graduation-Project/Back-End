using Croppilot.Core.Features.Product.Command.Models;
using Croppilot.Core.Features.Product.Query.Models;

namespace Croppilot.API.Controller;

/// <summary>
/// ProductController exposes endpoints for managing products, including listing, pagination, retrieval, creation, updating, and deletion of products.
/// 
/// Each endpoint returns a standardized response with:
/// - StatusCode: The HTTP status code of the response.
/// - Succeeded: A boolean indicating if the operation was successful.
/// - Message: A brief message for the operation.
/// - Data: The payload data (if applicable).
/// - Errors: A list of errors (if any), where each error contains:
///     - Code: A unique code for the error.
///     - Message: A description of the error.
///     - Field: The field that caused the error (if applicable).
/// 
/// Frontend developers should check the 'Succeeded' flag and, if false, review the 'Errors' list to determine the exact issues.
/// </summary>
[SwaggerResponse(200, "Operation completed successfully"), SwaggerResponse(400, "Invalid request or operation failed")]
[Authorize]
public class ProductController(IMediator mediator) : AppControllerBase
{
	/// <summary>
	/// Retrieves the complete list of products.
	/// Frontend: Use this endpoint to obtain all available products without pagination.
	/// </summary>
	[HttpGet("ProductsList"), SwaggerOperation(
		 Summary = "Retrieves all products",
		 Description = "**Fetches a complete list of products.**")]
	// [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
	[AllowAnonymous]
	public async Task<IActionResult> GetProducts()
	{
		var response = await mediator.Send(new GetAllProductQuery());
		return NewResult(response);
	}

	/// <summary>
	/// Retrieves a paginated list of products.
	/// Frontend: Supply pagination parameters (e.g., page number, page size) via query parameters.
	/// </summary>
	[HttpGet("paginatedList"), SwaggerOperation(
		 Summary = "Retrieves paginated products",
		 Description =
			 "**Fetches a paginated list of products based on query parameters." +
			 "Frontend: Supply pagination parameters (e.g., page number, page size) via query parameters**")]
	[AllowAnonymous]
	// [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
	public async Task<IActionResult> Paginated([FromQuery] GetProductPaginatedQuery query)
	{
		var response = await mediator.Send(query);
		return NewResult(response);
	}
	[HttpGet("ProductsByUserId"), SwaggerOperation(
		 Summary = "Retrieves products by user ID",
		 Description =
			 "**Fetches a list of products associated with a specific user.")]

	public async Task<IActionResult> GetProductsByUserId([FromQuery] GetProductsByUserId query)
	{
		var response = await mediator.Send(query);
		return NewResult(response);
	}

	/// <summary>
	/// Retrieves a specific product by its unique identifier.
	/// Frontend: Provide the product's ID in the route.
	/// </summary>
	[HttpGet("product/{id}"), SwaggerOperation(
		 Summary = "Retrieves a product by ID",
		 Description =
			 "**Fetches the details of a product using its unique identifier. Frontend: Provide the product's ID in the route**")]
	[AllowAnonymous]
	// [EnableRateLimiting(RateLimiters.ReadOperationsLimit)]
	public async Task<IActionResult> GetProductById([FromRoute] int id)
	{
		var response = await mediator.Send(new GetProductByIdQuery(id));
		return NewResult(response);
	}

	/// <summary>
	/// Creates a new product.
	/// Frontend: Provide product details (e.g., name, description, price, etc.) in the request body.
	/// </summary>
	[HttpPost("Product/Create"), SwaggerOperation(
		 Summary = "Creates a new product",
		 Description =
			 "**Adds a new product with the provided details.Frontend: Provide product details (e.g., name, description, price, etc.) in the request body.**")]
	// [EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
	public async Task<IActionResult> Create(AddProductCommand command)
	{
		var response = await mediator.Send(command);
		return NewResult(response);
	}

	/// <summary>
	/// Updates an existing product.
	/// Frontend: Provide updated product details, including the product ID, in the request body.
	/// </summary>
	[HttpPut("Product/Update"), SwaggerOperation(
		 Summary = "Updates an existing product",
		 Description = "**Modifies the details of an existing product.**")]
	// [EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
	public async Task<IActionResult> Edit(EditProductCommand command)
	{
		var response = await mediator.Send(command);
		return NewResult(response);
	}

	/// <summary>
	/// Deletes a product.
	/// Frontend: Provide the product's ID in the route to delete the product.
	/// </summary>
	[HttpDelete("ProductDelete/{id}"), SwaggerOperation(
		 Summary = "Deletes a product",
		 Description = "**Removes a product from the system using its unique identifier." +
					   "Frontend: Provide the product's ID in the route to delete the product.**")]
	// [EnableRateLimiting(RateLimiters.AdminEndpointsLimit)]
	public async Task<IActionResult> Delete([FromRoute] int id)
	{
		var response = await mediator.Send(new DeleteProductCommand(id));
		return NewResult(response);
	}
}