using Croppilot.Core.Bases;
using Croppilot.Core.Features.User.Queries.Result;
using MediatR;

namespace Croppilot.Core.Features.User.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUser>>
    {
        public string Id { get; set; }
        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
