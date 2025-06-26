using Croppilot.Core.Features.Product.Query.Models;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Comman;
using Croppilot.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace Croppilot.Core.Features.Product.Query.Handlers;

public class ProductHandlers(
	IProductServices productServices,
	IReviewService reviewService,
	IWishlistService wishlistService,
	IHttpContextAccessor httpContextAccessor)
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
		var wishList = await GetWishList();
		var productResult = productList.Adapt<List<GetAllProductResponse>>();
		
		// Calculate average rating for each product
		for (int i = 0; i < productResult.Count; i++)
		{
			var averageRating = await reviewService.GetAverageRatingByProductIdAsync(productResult[i].ProductId, cancellationToken);
			productResult[i] = productResult[i] with 
			{ 
				AverageRating = averageRating,
				IsFavorite = IsFavorite(wishList, productResult[i].ProductId) 
			};
		}
		
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
		var wishList = await GetWishList();
		var productResult = product.Adapt<GetProductByIdResponse>();
		productResult = productResult with
		{
			AverageRating = await reviewService.GetAverageRatingByProductIdAsync(product.Id, cancellationToken)
		};
		productResult = productResult with
		{
			IsFavorite = IsFavorite(wishList, product.Id)
		};

		return Success(productResult);
	}

	public async Task<Response<List<GetProductPaginatedResponse>>> Handle(GetProductPaginatedQuery request,
		CancellationToken cancellationToken)
	{
		var wishList = await GetWishList();
		Expression<Func<Date.Models.Product, GetProductPaginatedResponse>> expression = product =>
			new GetProductPaginatedResponse(
				product.Id,
				product.Name,
				product.Category.Name,
				product.Description,
				product.Price,
				product.Availability.ToString(),
				product.User.UserName,
				false,
				product.ProductImages.Select(img => img.ImageUrl).ToList()
			);

		var filteredQueryable = await productServices.FilterProductQueryable(request.OrderBy, request.Search);


		var paginatedList = await filteredQueryable.Select(expression)
			.ToPaginatedListAsync(request.PageNumber, request.PageSize);
		paginatedList.Data = paginatedList.Data.Select(p =>
			{
				return p with
				{
					IsFavorite = IsFavorite(wishList, p.ProductId)
				};
			}).ToList();

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

	private async Task<Wishlist?> GetWishList()
	{
		var userId = httpContextAccessor?.HttpContext?.User.GetUserId();
		return await wishlistService.GetWishlistByUserIdAsync(userId);
	}

	private bool IsFavorite(Wishlist? wishlist, int productId)
	{
		if (wishlist?.WishlistItems is not null)
		{
			return wishlist.WishlistItems.Any(wi => wi.ProductId == productId);
		}
		return false;
	}
}