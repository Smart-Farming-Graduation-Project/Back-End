namespace Croppilot.Core.Features.Product.Query.Result;

// Global product data without user-specific fields
public record GlobalProductPaginatedResponse(
	int ProductId,
	string ProductName,
	string CategoryName,
	string Description,
	decimal Price,
	string Availability,
	string ProductOwner,
	List<string> Images
);

// Complete response including user-specific data
public record GetProductPaginatedResponse(
	int ProductId,
	string ProductName,
	string CategoryName,
	string Description,
	decimal Price,
	string Availability,
	string ProductOwner,
	bool? IsFavorite,
	List<string> Images
);