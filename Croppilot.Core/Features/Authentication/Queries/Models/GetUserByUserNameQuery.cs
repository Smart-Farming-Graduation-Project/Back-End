using Croppilot.Core.Bases;
using Croppilot.Core.Features.Authentication.Queries.Result;
using MediatR;

namespace Croppilot.Core.Features.Authentication.Queries.Models
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
