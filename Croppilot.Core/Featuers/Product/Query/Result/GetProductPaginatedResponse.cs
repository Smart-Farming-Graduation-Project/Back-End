namespace Croppilot.Core.Featuers.Product.Query.Result
{
    public class GetProductPaginatedResponse(int prodId, string prodName, string categoryName, string Desc, decimal price, string avilibilty, List<string> iamge)
    {
        public int ProductId { get; set; } = prodId;
        public string ProductName { get; set; } = prodName;
        public string CategoryName { get; set; } = categoryName;
        public string Description { get; set; } = Desc;
        public decimal Price { get; set; } = price;
        public string Availability { get; set; } = avilibilty;
        public List<string> Images { get; set; } = iamge;

    }
}
