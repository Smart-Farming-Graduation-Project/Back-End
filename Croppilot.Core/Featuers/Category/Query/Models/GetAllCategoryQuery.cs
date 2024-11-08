using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Category.Query.Result;
using MediatR;

namespace Croppilot.Core.Featuers.Category.Query.Models
{
    public class GetAllCategoryQuery : IRequest<Response<List<GetAllCategoryResponse>>>
    {
    }
}
