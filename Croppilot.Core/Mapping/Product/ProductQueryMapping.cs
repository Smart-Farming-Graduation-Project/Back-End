namespace Croppilot.Core.Mapping.Product;

public class ProductQueryMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Mapping for GetProductByIdResponse from Product
        config.NewConfig<Date.Models.Product, GetProductByIdResponse>()
            .Map(dest => dest.ProductId, src => src.Id)
            .Map(dest => dest.ProductName, src => src.Name)
            .Map(dest => dest.CategoryName, src => src.Category.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Availability, src => src.Availability.ToString())
            .Map(dest => dest.Images, src => src.ProductImages.Select(img => img.ImageUrl).ToList());

        // Mapping for GetAllProductResponse from Product
        config.NewConfig<Date.Models.Product, GetAllProductResponse>()
            .Map(dest => dest.ProductId, src => src.Id)
            .Map(dest => dest.ProductName, src => src.Name)
            .Map(dest => dest.CategoryName, src => src.Category.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Availability, src => src.Availability.ToString())
            .Map(dest => dest.Images, src => src.ProductImages.Select(img => img.ImageUrl).ToList());

        // Mapping for GetProductPaginatedResponse from Product
        config.NewConfig<Date.Models.Product, GetProductPaginatedResponse>()
            .Map(dest => dest.ProductId, src => src.Id)
            .Map(dest => dest.ProductName, src => src.Name)
            .Map(dest => dest.CategoryName, src => src.Category.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Availability, src => src.Availability.ToString())
            .Map(dest => dest.Images, src => src.ProductImages.Select(img => img.ImageUrl).ToList());
    }
}