namespace Croppilot.Core.Features.Product.Query.Result;

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