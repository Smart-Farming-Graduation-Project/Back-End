namespace Croppilot.Core.Featuers.Product.Query.GetProduct
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Availability { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}
