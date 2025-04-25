using Croppilot.Core.Features.Category.Query.Models;
using Croppilot.Core.Features.Category.Query.Result;
using Croppilot.Infrastructure.Comman;
using System.Linq.Expressions;

namespace Croppilot.Core.Features.Category.Query.Handlers;

public class CategoryHandlers(ICategoryService categoryService)
    : ResponseHandler
        , IRequestHandler<GetAllCategoryQuery, Response<List<GetAllCategoryResponse>>>,
        IRequestHandler<GetCategoryByIdQuery, Response<GetCategoryByIdResponse>>,
        IRequestHandler<GetCategoryPaginatedQuery, Response<List<GetCategoryPaginatedResponse>>>
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
        var category = await categoryService.GetByIdAsync(request.Id,
            includeProperties: ["Products", "Products.ProductImages"],
            cancellationToken: cancellationToken);
        if (category is null)
            return NotFound<GetCategoryByIdResponse>("This category Is Not Found");

        var categoryResult = category.Adapt<GetCategoryByIdResponse>();

        return Success(categoryResult);
    }

    public async Task<Response<List<GetCategoryPaginatedResponse>>> Handle(GetCategoryPaginatedQuery request,
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
            await categoryService.GetAllAsync(includeProperties: ["Products"],
                cancellationToken: cancellationToken);

        var filterQueryable = await categoryService.FilterCategoryQueryable(request.OrderBy, request.Search);

        var paginatedList = await filterQueryable.Select(expression)
            .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        var categoryMeta = new Dictionary<string, object>
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

        return Success(paginatedList.Data, meta: categoryMeta);
    }
}