namespace Croppilot.Core.Features.Product.Command.Models;

public class EditProductCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public Availability Availability { get; set; }
    public List<IFormFile> Images { get; set; } = new();
}