namespace Croppilot.Core.Features.Category.Query.Result
{
	public class GetCategoryPaginatedResponse(int categoryId, string categoryName, string categoryDescription, string categoryImage, List<ProductDto> products)

	{
		public int CategoryId { get; set; } = categoryId;
		public string CategoryName { get; set; } = categoryName;
		public string CategoryDescription { get; set; } = categoryDescription;
		public string CategoryImage { get; set; } = categoryImage;
		public List<ProductDto> Products { get; set; } = products;

	}
}
