namespace Croppilot.Core.Features.Product.Query.Result;

public record GetProductPaginatedResponse(
    int ProductId,
    string ProductName,
    string CategoryName,
    string Description,
    decimal Price,
    string Availability,
    List<string> Images
);