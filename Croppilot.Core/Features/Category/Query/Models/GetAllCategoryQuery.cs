using Croppilot.Core.Bases;
using Croppilot.Core.Features.Category.Query.Result;
using MediatR;

namespace Croppilot.Core.Features.Category.Query.Models
{
    public class GetAllCategoryQuery : IRequest<Response<List<GetAllCategoryResponse>>>
    {
    }
}
