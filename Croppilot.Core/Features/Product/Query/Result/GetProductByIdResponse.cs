namespace Croppilot.Core.Features.Product.Query.Result;

public record GetProductByIdResponse(
	int ProductId,
	string ProductName,
	string CategoryName,
	string Description,
	decimal Price,
	string Availability,
	double AverageRating,
	string ProductOwner,
	List<string> Images
);