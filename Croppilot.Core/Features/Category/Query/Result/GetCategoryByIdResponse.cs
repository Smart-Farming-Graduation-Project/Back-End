using Croppilot.Core.Features.Category.Query.Models;

namespace Croppilot.Core.Features.Category.Query.Result
{
    public class GetCategoryByIdResponse : IRequest<Response<GetCategoryByIdQuery>>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; } = string.Empty;

        public List<ProductDto> Products { get; set; } = new();

    }
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Availability { get; set; }
        public decimal Price { get; set; }
        public List<string> Images { get; set; } = new();
    }
}
