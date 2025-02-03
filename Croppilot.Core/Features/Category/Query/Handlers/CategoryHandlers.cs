using System.Linq.Expressions;
using Croppilot.Core.Bases;
using Croppilot.Core.Features.Category.Query.Models;
using Croppilot.Core.Features.Category.Query.Result;
using Croppilot.Infrastructure.Comman;
using Croppilot.Services.Abstract;
using MediatR;

namespace Croppilot.Core.Features.Category.Query.Handlers
{
    public class CategoryHandlers(ICategoryService categoryService)
        : ResponseHandler
            , IRequestHandler<GetAllCategoryQuery, Response<List<GetAllCategoryResponse>>>,
            IRequestHandler<GetCategoryByIdQuery, Response<GetCategoryByIdResponse>>,
            IRequestHandler<GetCategoryPaginatedQuery, PaginatedResult<GetCategoryPaginatedResponse>>
    {
        public async Task<Response<List<GetAllCategoryResponse>>> Handle(GetAllCategoryQuery request,
            CancellationToken cancellationToken)
        {
            var categoryList = await categoryService.GetAllAsync(cancellationToken: cancellationToken);
            var categoryResult = categoryList.Select(x => new GetAllCategoryResponse()
            {
                CategoryId = x.Id,
                CategoryName = x.Name,
                CategoryDescription = x.Description
            }).ToList();

            var result = Success(categoryResult);
            result.Meta = new Dictionary<string, object>
            {
                { "count", categoryResult.Count }
            };

            return result;
        }

        public async Task<Response<GetCategoryByIdResponse>> Handle(GetCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var category = await categoryService.GetByIdAsync(request.Id, includeProperties: "Products",
                cancellationToken: cancellationToken);
            if (category is null)
                return NotFound<GetCategoryByIdResponse>("This category Is Not Found");

            var categoryResult = new GetCategoryByIdResponse()
            {
                CategoryId = category.Id,
                CategoryName = category.Name,
                CategoryDescription = category.Description,
                Products = category.Products.Select(p => new ProductDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    Price = p.Price,
                    Availability = p.Availability.ToString()
                }).ToList()
            };
            return Success(categoryResult);
        }

        public async Task<PaginatedResult<GetCategoryPaginatedResponse>> Handle(GetCategoryPaginatedQuery request,
            CancellationToken cancellationToken)
        {
            Expression<Func<Date.Models.Category, GetCategoryPaginatedResponse>> expression = c =>
                new GetCategoryPaginatedResponse(
                    c.Id,
                    c.Name ?? string.Empty,
                    c.Description ?? string.Empty,
                    c.Products
                        .Skip((request.ProductPageNumber - 1) * request.ProductPageSize) // Apply pagination
                        .Take(request.ProductPageSize)
                        .Select(p => new ProductDto
                        {
                            ProductId = p.Id,
                            ProductName = p.Name ?? string.Empty,
                            Price = p.Price,
                            Availability = p.Availability.ToString()
                        }).ToList()
                );
            var categoryList =
                await categoryService.GetAllAsync(includeProperties: "Products", cancellationToken: cancellationToken);

            var filterQueryable = await categoryService.FilterCategoryQueryable(request.OrderBy, request.Search);

            var paginatedList = await filterQueryable.Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            paginatedList.Meta = new
            {
                Count = paginatedList.Data.Count()
            };

            return paginatedList;
        }
    }
}