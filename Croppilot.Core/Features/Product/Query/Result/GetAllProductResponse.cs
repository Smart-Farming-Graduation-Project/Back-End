namespace Croppilot.Core.Features.Product.Query.Result;

// Global product data without user-specific fields
public record GlobalProductResponse(
	int ProductId,
	string ProductName,
	string CategoryName,
	string? Description,
	decimal? Price,
	string Availability,
	double AverageRating,
	string ProductOwner,
	List<string> Images
);

// Complete response including user-specific data
public record GetAllProductResponse(
	int ProductId,
	string ProductName,
	string CategoryName,
	string? Description,
	decimal? Price,
	string Availability,
	double AverageRating,
	string ProductOwner,
	bool IsFavorite,
	List<string> Images
);