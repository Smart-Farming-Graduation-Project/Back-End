using Croppilot.Core.Bases;
using Croppilot.Core.Features.User.Queries.Result;
using MediatR;

namespace Croppilot.Core.Features.User.Queries.Models
{
    public class GetUserByUserNameQuery : IRequest<Response<GetUser>>
    {
        public string UserName { get; set; }
        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
