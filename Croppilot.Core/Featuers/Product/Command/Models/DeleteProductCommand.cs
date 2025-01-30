using Croppilot.Core.Bases;
using MediatR;

namespace Croppilot.Core.Featuers.Product.Command.Models
{
    public class DeleteProductCommand(int id) : IRequest<Response<string>>
    {
        public int Id { get; set; } = id;
    }
}
