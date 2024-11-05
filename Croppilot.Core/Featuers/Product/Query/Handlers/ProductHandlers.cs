using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Product.Query.Models;
using Croppilot.Core.Featuers.Product.Query.Result;
using Croppilot.Infrastructure.Comman;
using Croppilot.Services.Abstract;
using MediatR;
using System.Linq.Expressions;

namespace Croppilot.Core.Featuers.Product.Query.Handlers
{
    public class ProductHandlers(IProductServices productServices)
        : ResponseHandler
            , IRequestHandler<GetAllProductQuery, Response<List<GetAllProductResponse>>>,
            IRequestHandler<GetProductByIdQueryy, Response<GetProductByIdResponse>>,
            IRequestHandler<GetProductPaginatedQuery, PaginatedResult<GetProductPaginatedResponse>>
    {
        public async Task<Response<List<GetAllProductResponse>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var productList = await productServices.GetAll(includeProperties: "Category,ProductImages", cancellationToken: cancellationToken);
            var producttResult = productList.Select(x => new GetAllProductResponse
            {
                ProductId = x.Id,
                ProductName = x.Name,
                CategoryName = x.Category.Name,
                Description = x.Description,
                Price = x.Price,
                Availability = x.Availability.ToString(),
                Images = x.ProductImages.Select(x => x.ImageUrl).ToList()
            }).ToList();
            //When you use Automapper Uncomment this code

            // var productListMapper = mapper.Map<List<GetAllProductResponse>>(productList);
            var result = Success(producttResult); //Fun In Response Handler
            result.Meta = new
            {
                Count = producttResult.Count()
            };
            return result;
        }

        public async Task<Response<GetProductByIdResponse>> Handle(GetProductByIdQueryy request, CancellationToken cancellationToken)
        {
            var product = await productServices.GetById(request.Id, includeProperties: "Category,ProductImages", cancellationToken: cancellationToken);
            if (product is null)
                return NotFound<GetProductByIdResponse>("This Product Is Not Found");

            var productResult = new GetProductByIdResponse
            {
                ProductId = product.Id,
                ProductName = product.Name,
                CategoryName = product.Category.Name,
                Description = product.Description,
                Price = product.Price,
                Availability = product.Availability.ToString(),
                Images = product.ProductImages.Select(img => img.ImageUrl).ToList()
            };
            return Success(productResult);
        }

        public async Task<PaginatedResult<GetProductPaginatedResponse>> Handle(GetProductPaginatedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Date.Models.Product, GetProductPaginatedResponse>> expression = e =>
                new GetProductPaginatedResponse(
                    e.Id,
                    e.Name ?? string.Empty,
                    e.Category.Name ?? "Unknown",
                    e.Description ?? string.Empty,
                    e.Price,
                    e.Availability.ToString(),
                    e.ProductImages != null ? e.ProductImages.Select(x => x.ImageUrl).ToList() : new List<string>()
                );

            var productList = await productServices.GetAll(includeProperties: "Category,ProductImages", cancellationToken: cancellationToken);
            var filterQurayble = await productServices.FilterProductQueryable(request.OrderBy, request.Search);

            var paginatedList = await filterQurayble.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

            paginatedList.Meta = new
            {
                Count = paginatedList.Data.Count()
            };
            return paginatedList;
        }

    }
}
