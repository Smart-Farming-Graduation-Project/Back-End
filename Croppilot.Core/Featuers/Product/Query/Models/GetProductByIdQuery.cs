using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Product.Query.Result;
using MediatR;

namespace Croppilot.Core.Featuers.Product.Query.Models
{
    public class GetProductByIdQueryy(int id) : IRequest<Response<GetProductByIdResponse>>
    {
        public int Id { get; set; } = id;
    }
}
