namespace Croppilot.Core.Features.Product.Query.Result;

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