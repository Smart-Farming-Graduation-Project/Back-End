using Croppilot.Core.Bases;
using Croppilot.Core.Features.Category.Query.Result;
using MediatR;

namespace Croppilot.Core.Features.Category.Query.Models
{
    public class GetCategoryByIdQuery(int id) : IRequest<Response<GetCategoryByIdResponse>>
    {
        public int Id { get; set; } = id;
    }
}
