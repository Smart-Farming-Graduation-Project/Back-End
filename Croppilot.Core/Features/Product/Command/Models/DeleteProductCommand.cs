namespace Croppilot.Core.Features.Product.Command.Models
{
    public class DeleteProductCommand(int id) : IRequest<Response<string>>
    {
        public int Id { get; set; } = id;
    }
}
