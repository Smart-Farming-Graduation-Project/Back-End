namespace Croppilot.Date.DTOS;

public class GEtProductDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Availability { get; set; }
    public List<string> Images { get; set; }

}