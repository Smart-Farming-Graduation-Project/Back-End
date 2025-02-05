using Mapster;

namespace Croppilot.Core.Mapping.Product;

public class ProductCommandMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Mapping for AddProductCommand to Product
        config.NewConfig<AddProductCommand, Date.Models.Product>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Availability, src => src.Availability)
            .Ignore(dest => dest.Id) 
            .Ignore(dest => dest.CreatedAt)
            .Ignore(dest => dest.UpdatedAt);

        // Mapping for EditProductCommand to Product (used for update)
        config.NewConfig<EditProductCommand, Date.Models.Product>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.Availability, src => src.Availability)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.UpdatedAt, src => DateTime.UtcNow) // Update times on edit
            .Ignore(dest => dest.CreatedAt) // CreatedAt should remain the same
            .Ignore(dest => dest.ProductImages); // Handle images separately

        // Mapping for DeleteProductCommand to Product (only the Id is used here)
        config.NewConfig<DeleteProductCommand, Date.Models.Product>()
            .Map(dest => dest.Id, src => src.Id)
            .Ignore(dest => dest.Name)
            .Ignore(dest => dest.Description)
            .Ignore(dest => dest.Price)
            .Ignore(dest => dest.Availability)
            .Ignore(dest => dest.CreatedAt)
            .Ignore(dest => dest.UpdatedAt)
            .Ignore(dest => dest.ProductImages);
    }
}
