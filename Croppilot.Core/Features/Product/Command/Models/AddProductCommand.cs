namespace Croppilot.Core.Features.Product.Command.Models;

public class AddProductCommand : IRequest<Response<string>>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public Availability Availability { get; set; }
    public IFormFileCollection Images { get; set; } = new FormFileCollection();
}