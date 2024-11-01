using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Product.Query.Result;
using MediatR;

namespace Croppilot.Core.Featuers.Product.Query.Models
{
    public class GetAllProductQuery : IRequest<Response<List<GetAllProductResponse>>>
    {

    }


}
