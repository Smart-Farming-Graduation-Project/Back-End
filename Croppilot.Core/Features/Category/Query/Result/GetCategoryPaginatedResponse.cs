namespace Croppilot.Core.Features.Category.Query.Result
{
    public class GetCategoryPaginatedResponse(int categoryId, string categoryName, string categoryDescription, List<ProductDto> products)

    {
        public int CategoryId { get; set; } = categoryId;
        public string CategoryName { get; set; } = categoryName;
        public string CategoryDescription { get; set; } = categoryDescription;
        public List<ProductDto> Products { get; set; } = products;

    }
}
