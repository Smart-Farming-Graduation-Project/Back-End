using Croppilot.Core.Features.Category.Query.Result;
using Croppilot.Date.Models;

namespace Croppilot.Core.Mapping.Categories;

public class CategoryQueryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Category, GetCategoryByIdResponse>()
            .Map(dest => dest.CategoryId, src => src.Id)
            .Map(dest => dest.CategoryName, src => src.Name)
            .Map(dest => dest.CategoryDescription, src => src.Description)
            .Map(dest => dest.Products, src => src.Products.Adapt<List<ProductDto>>());

        config.NewConfig<Date.Models.Product, ProductDto>()
            .Map(dest => dest.ProductId, src => src.Id)
            .Map(dest => dest.ProductName, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Availability, src => src.Availability.ToString())
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Images, src => src.ProductImages.Select(img => img.ImageUrl).ToList());
    }
}