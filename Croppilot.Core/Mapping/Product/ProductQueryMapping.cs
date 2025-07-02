using Croppilot.Core.Features.Product.Query.Result;

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
			.Map(dest => dest.ProductOwner, src => src.User.UserName)
			.Map(dest => dest.Images, src => src.ProductImages.Select(img => img.ImageUrl).ToList());

		// Mapping for GetAllProductResponse from Product
		config.NewConfig<Date.Models.Product, GetAllProductResponse>()
			.Map(dest => dest.ProductId, src => src.Id)
			.Map(dest => dest.ProductName, src => src.Name)
			.Map(dest => dest.CategoryName, src => src.Category.Name)
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Price, src => src.Price)
			.Map(dest => dest.Availability, src => src.Availability.ToString())
			.Map(dest => dest.ProductOwner, src => src.User.UserName)
			.Map(dest => dest.AverageRating, src => 0.0)
			.Map(dest => dest.IsFavorite, src => false)
			.Map(dest => dest.Images, src => src.ProductImages.Select(img => img.ImageUrl).ToList());

		// Mapping for GlobalProductResponse from Product (without user-specific data)
		config.NewConfig<Date.Models.Product, GlobalProductResponse>()
			.Map(dest => dest.ProductId, src => src.Id)
			.Map(dest => dest.ProductName, src => src.Name)
			.Map(dest => dest.CategoryName, src => src.Category.Name)
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Price, src => src.Price)
			.Map(dest => dest.Availability, src => src.Availability.ToString())
			.Map(dest => dest.ProductOwner, src => src.User.UserName)
			.Map(dest => dest.AverageRating, src => 0.0)
			.Map(dest => dest.Images, src => src.ProductImages.Select(img => img.ImageUrl).ToList());

		// Mapping for GlobalProductByIdResponse from Product (without user-specific data)
		config.NewConfig<Date.Models.Product, GlobalProductByIdResponse>()
			.Map(dest => dest.ProductId, src => src.Id)
			.Map(dest => dest.ProductName, src => src.Name)
			.Map(dest => dest.CategoryName, src => src.Category.Name)
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Price, src => src.Price)
			.Map(dest => dest.Availability, src => src.Availability.ToString())
			.Map(dest => dest.ProductOwner, src => src.User.UserName)
			.Map(dest => dest.AverageRating, src => 0.0)
			.Map(dest => dest.Images, src => src.ProductImages.Select(img => img.ImageUrl).ToList());

		// Mapping for GlobalProductPaginatedResponse from Product (without user-specific data)
		config.NewConfig<Date.Models.Product, GlobalProductPaginatedResponse>()
			.Map(dest => dest.ProductId, src => src.Id)
			.Map(dest => dest.ProductName, src => src.Name)
			.Map(dest => dest.CategoryName, src => src.Category.Name)
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Price, src => src.Price)
			.Map(dest => dest.Availability, src => src.Availability.ToString())
			.Map(dest => dest.ProductOwner, src => src.User.UserName)
			.Map(dest => dest.Images, src => src.ProductImages.Select(img => img.ImageUrl).ToList());

		// Helper mappings for merging global and user-specific data
		config.NewConfig<GlobalProductResponse, GetAllProductResponse>()
			.Map(dest => dest.ProductId, src => src.ProductId)
			.Map(dest => dest.ProductName, src => src.ProductName)
			.Map(dest => dest.CategoryName, src => src.CategoryName)
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Price, src => src.Price)
			.Map(dest => dest.Availability, src => src.Availability)
			.Map(dest => dest.AverageRating, src => src.AverageRating)
			.Map(dest => dest.ProductOwner, src => src.ProductOwner)
			.Map(dest => dest.Images, src => src.Images)
			.Map(dest => dest.IsFavorite, src => false); // Will be set separately

		config.NewConfig<GlobalProductByIdResponse, GetProductByIdResponse>()
			.Map(dest => dest.ProductId, src => src.ProductId)
			.Map(dest => dest.ProductName, src => src.ProductName)
			.Map(dest => dest.CategoryName, src => src.CategoryName)
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Price, src => src.Price)
			.Map(dest => dest.Availability, src => src.Availability)
			.Map(dest => dest.AverageRating, src => src.AverageRating)
			.Map(dest => dest.ProductOwner, src => src.ProductOwner)
			.Map(dest => dest.Images, src => src.Images)
			.Map(dest => dest.IsFavorite, src => false); // Will be set separately

		config.NewConfig<GlobalProductPaginatedResponse, GetProductPaginatedResponse>()
			.Map(dest => dest.ProductId, src => src.ProductId)
			.Map(dest => dest.ProductName, src => src.ProductName)
			.Map(dest => dest.CategoryName, src => src.CategoryName)
			.Map(dest => dest.Description, src => src.Description)
			.Map(dest => dest.Price, src => src.Price)
			.Map(dest => dest.Availability, src => src.Availability)
			.Map(dest => dest.ProductOwner, src => src.ProductOwner)
			.Map(dest => dest.Images, src => src.Images)
			.Map(dest => dest.IsFavorite, src => false); // Will be set separately
	}
}