using Croppilot.Core.Features.Product.Query.Models;
using Croppilot.Infrastructure.Comman;
using System.Linq.Expressions;

namespace Croppilot.Core.Features.Product.Query.Handlers;

public class ProductHandlers(IProductServices productServices, IReviewService reviewService)
	: ResponseHandler,
		IRequestHandler<GetAllProductQuery, Response<List<GetAllProductResponse>>>,
		IRequestHandler<GetProductByIdQuery, Response<GetProductByIdResponse>>,
		IRequestHandler<GetProductPaginatedQuery, Response<List<GetProductPaginatedResponse>>>
{
	public async Task<Response<List<GetAllProductResponse>>> Handle(GetAllProductQuery request,
		CancellationToken cancellationToken)
	{
		var productList = await productServices.GetAll(includeProperties: ["Category", "ProductImages", "User"],
			cancellationToken: cancellationToken);

		var productResult = productList.Adapt<List<GetAllProductResponse>>();

		var result = Success(productResult);
		result.Meta = new Dictionary<string, object> { { "count", productResult.Count } };

		return result;
	}

	public async Task<Response<GetProductByIdResponse>> Handle(GetProductByIdQuery request,
		CancellationToken cancellationToken)
	{
		var product = await productServices.GetByIdAsync(request.Id, includeProperties: ["Category", "ProductImages", "User"],
			cancellationToken: cancellationToken);

		if (product is null)
			return NotFound<GetProductByIdResponse>("This Product Is Not Found");

		var productResult = product.Adapt<GetProductByIdResponse>();
		productResult = productResult with
		{
			AverageRating = await reviewService.GetAverageRatingByProductIdAsync(product.Id, cancellationToken)
		};

		return Success(productResult);
	}

	public async Task<Response<List<GetProductPaginatedResponse>>> Handle(GetProductPaginatedQuery request,
		CancellationToken cancellationToken)
	{
		Expression<Func<Date.Models.Product, GetProductPaginatedResponse>> expression = product =>
			new GetProductPaginatedResponse(
				product.Id,
				product.Name,
				product.Category.Name,
				product.Description,
				product.Price,
				product.Availability.ToString(),
				product.User.UserName,
				product.ProductImages.Select(img => img.ImageUrl).ToList()
			);

		var filteredQueryable = await productServices.FilterProductQueryable(request.OrderBy, request.Search);

		var paginatedList = await filteredQueryable.Select(expression)
			.ToPaginatedListAsync(request.PageNumber, request.PageSize);

		var productMeta = new Dictionary<string, object>
		{
			{"Current Page", paginatedList.CurrentPage},
			{"Total Pages", paginatedList.TotalPages},
			{"Page Size", paginatedList.PageSize},
			{"Total Count", paginatedList.TotalCount},
			{"Has Next", paginatedList.HasNextPage},
			{"Has Previous", paginatedList.HasPreviousPage},
			{"Meta", paginatedList.Meta},
			{"Succeeded", paginatedList.Succeeded},
			{"Message", paginatedList.Messages}
		};

		return Success(paginatedList.Data, meta: productMeta);
	}
}