using Croppilot.Core.Features.Product.Query.Models;
using Croppilot.Core.Features.Product.Query.Result;
using Croppilot.Date.Models;
using Croppilot.Infrastructure.Comman;
using Croppilot.Infrastructure.Extensions;
using System.Linq.Expressions;

namespace Croppilot.Core.Features.Product.Query.Handlers;

public class ProductHandlers(
	IProductServices productServices,
	IReviewService reviewService,
	IWishlistService wishlistService,
	IUserFavoritesService userFavoritesService,
	ICacheService cacheService,
	ICacheKeyGenerator cacheKeyGenerator,
	IHttpContextAccessor httpContextAccessor)
	: ResponseHandler,
		IRequestHandler<GetAllProductQuery, Response<List<GetAllProductResponse>>>,
		IRequestHandler<GetProductByIdQuery, Response<GetProductByIdResponse>>,
		IRequestHandler<GetProductPaginatedQuery, Response<List<GetProductPaginatedResponse>>>,
		IRequestHandler<GetProductsByUserIdQuery, Response<List<GetAllProductResponse>>>
{
	public async Task<Response<List<GetAllProductResponse>>> Handle(GetAllProductQuery request,
		CancellationToken cancellationToken)
	{
		// Step 1: Get or cache global product data (without user-specific data)
		var globalProducts = await GetOrCacheGlobalProductsAsync(cancellationToken);
		
		// Step 2: Get user-specific favorite data
		var userId = GetCurrentUserId();
		var productIds = globalProducts.Select(p => p.ProductId).ToList();
		var userFavorites = await userFavoritesService.GetUserFavoritesAsync(userId, productIds, cancellationToken);
		
		// Step 3: Merge global data with user-specific data
		var finalProducts = globalProducts.Select(global => global.Adapt<GetAllProductResponse>() with
		{
			IsFavorite = userFavorites.GetValueOrDefault(global.ProductId, false)
		}).ToList();
		
		var result = Success(finalProducts);
		result.Meta = new Dictionary<string, object> { { "count", finalProducts.Count } };

		return result;
	}

	public async Task<Response<GetProductByIdResponse>> Handle(GetProductByIdQuery request,
		CancellationToken cancellationToken)
	{
		// Step 1: Get or cache global product data (without user-specific data)
		var globalProduct = await GetOrCacheGlobalProductByIdAsync(request.Id, cancellationToken);
		
		if (globalProduct is null)
			return NotFound<GetProductByIdResponse>("This Product Is Not Found");
		
		// Step 2: Get user-specific favorite data
		var userId = GetCurrentUserId();
		var isFavorite = await userFavoritesService.GetUserFavoriteAsync(userId, request.Id, cancellationToken);
		
		// Step 3: Merge global data with user-specific data
		var finalProduct = globalProduct.Adapt<GetProductByIdResponse>() with
		{
			IsFavorite = isFavorite
		};

		return Success(finalProduct);
	}

	public async Task<Response<List<GetProductPaginatedResponse>>> Handle(GetProductPaginatedQuery request,
		CancellationToken cancellationToken)
	{
		// Step 1: Get or cache global product data (without user-specific data)
		var globalPaginatedResult = await GetOrCacheGlobalProductsPaginatedAsync(request, cancellationToken);
		
		// Step 2: Get user-specific favorite data
		var userId = GetCurrentUserId();
		var productIds = globalPaginatedResult.Data.Select(p => p.ProductId).ToList();
		var userFavorites = await userFavoritesService.GetUserFavoritesAsync(userId, productIds, cancellationToken);
		
		// Step 3: Merge global data with user-specific data
		var finalProducts = globalPaginatedResult.Data.Select(global => global.Adapt<GetProductPaginatedResponse>() with
		{
			IsFavorite = userFavorites.GetValueOrDefault(global.ProductId, false)
		}).ToList();

		var productMeta = new Dictionary<string, object>
		{
			{"Current Page", globalPaginatedResult.CurrentPage},
			{"Total Pages", globalPaginatedResult.TotalPages},
			{"Page Size", globalPaginatedResult.PageSize},
			{"Total Count", globalPaginatedResult.TotalCount},
			{"Has Next", globalPaginatedResult.HasNextPage},
			{"Has Previous", globalPaginatedResult.HasPreviousPage},
			{"Meta", globalPaginatedResult.Meta},
			{"Succeeded", globalPaginatedResult.Succeeded},
			{"Message", globalPaginatedResult.Messages}
		};

		return Success(finalProducts, meta: productMeta);
	}

	public async Task<Response<List<GetAllProductResponse>>> Handle(GetProductsByUserIdQuery request,
		CancellationToken cancellationToken)
	{
		// Step 1: Get products by user ID
		var userProducts = await GetOrCacheUserProductsAsync(request.UserId, cancellationToken);
		
		// Step 2: Get user-specific favorite data (the requester's favorites, not the product owner's)
		var currentUserId = GetCurrentUserId();
		var productIds = userProducts.Select(p => p.ProductId).ToList();
		var userFavorites = await userFavoritesService.GetUserFavoritesAsync(currentUserId, productIds, cancellationToken);
		
		// Step 3: Merge product data with current user's favorite data
		var finalProducts = userProducts.Select(product => product.Adapt<GetAllProductResponse>() with
		{
			IsFavorite = userFavorites.GetValueOrDefault(product.ProductId, false)
		}).ToList();
		
		var result = Success(finalProducts);
		result.Meta = new Dictionary<string, object> { { "count", finalProducts.Count } };

		return result;
	}

	private async Task<List<GlobalProductResponse>> GetOrCacheUserProductsAsync(string userId, CancellationToken cancellationToken)
	{
		var cacheKey = cacheKeyGenerator.GenerateUserKey(userId, "user-products");
		
		return await cacheService.GetOrSetAsync(
			cacheKey,
			async () =>
			{
				var productList = await productServices.GetAll(
					includeProperties: ["Category", "ProductImages", "User"],
					cancellationToken: cancellationToken);
				
				// Filter products by user ID
				var userProducts = productList.Where(p => p.UserId == userId).ToList();
				var globalProducts = userProducts.Adapt<List<GlobalProductResponse>>();
				
				// Calculate average rating for each product
				for (int i = 0; i < globalProducts.Count; i++)
				{
					var averageRating = await reviewService.GetAverageRatingByProductIdAsync(
						globalProducts[i].ProductId, cancellationToken);
					globalProducts[i] = globalProducts[i] with { AverageRating = averageRating };
				}
				
				return globalProducts;
			},
			TimeSpan.FromMinutes(15), // Cache user products for 15 minutes
			cancellationToken);
	}

	private async Task<List<GlobalProductResponse>> GetOrCacheGlobalProductsAsync(CancellationToken cancellationToken)
	{
		var cacheKey = cacheKeyGenerator.GenerateCollectionKey("global-products");
		
		return await cacheService.GetOrSetAsync(
			cacheKey,
			async () =>
			{
				var productList = await productServices.GetAll(
					includeProperties: ["Category", "ProductImages", "User"],
					cancellationToken: cancellationToken);
				
				var globalProducts = productList.Adapt<List<GlobalProductResponse>>();
				
				// Calculate average rating for each product
				for (int i = 0; i < globalProducts.Count; i++)
				{
					var averageRating = await reviewService.GetAverageRatingByProductIdAsync(
						globalProducts[i].ProductId, cancellationToken);
					globalProducts[i] = globalProducts[i] with { AverageRating = averageRating };
				}
				
				return globalProducts;
			},
			TimeSpan.FromMinutes(30), // Cache global products for 30 minutes
			cancellationToken);
	}

	private async Task<GlobalProductByIdResponse?> GetOrCacheGlobalProductByIdAsync(int productId, CancellationToken cancellationToken)
	{
		var cacheKey = cacheKeyGenerator.GenerateKey("global-product", productId);
		
		return await cacheService.GetOrSetAsync(
			cacheKey,
			async () =>
			{
				var product = await productServices.GetByIdAsync(productId,
					includeProperties: ["Category", "ProductImages", "User"],
					cancellationToken: cancellationToken);

				if (product is null) return null;
				
				var globalProduct = product.Adapt<GlobalProductByIdResponse>();
				var averageRating = await reviewService.GetAverageRatingByProductIdAsync(product.Id, cancellationToken);
				
				return globalProduct with { AverageRating = averageRating };
			},
			TimeSpan.FromHours(1), // Cache individual products for 1 hour
			cancellationToken);
	}

	private async Task<PaginatedResult<GlobalProductPaginatedResponse>> GetOrCacheGlobalProductsPaginatedAsync(
		GetProductPaginatedQuery request, CancellationToken cancellationToken)
	{
		// Create cache key based on pagination parameters
		var cacheKey = cacheKeyGenerator.GeneratePaginatedKey(
			"global-products", 
			request.PageNumber, 
			request.PageSize,
			$"orderBy:{request.OrderBy}",
			$"search:{request.Search ?? ""}");
		
		return await cacheService.GetOrSetAsync(
			cacheKey,
			async () =>
			{
				Expression<Func<Date.Models.Product, GlobalProductPaginatedResponse>> expression = product =>
					new GlobalProductPaginatedResponse(
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
				return await filteredQueryable.Select(expression)
					.ToPaginatedListAsync(request.PageNumber, request.PageSize);
			},
			TimeSpan.FromMinutes(15), // Cache paginated results for 15 minutes
			cancellationToken);
	}

	private string GetCurrentUserId()
	{
		return httpContextAccessor?.HttpContext?.User.GetUserId() ?? string.Empty;
	}
}