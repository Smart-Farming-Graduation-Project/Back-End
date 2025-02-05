using Croppilot.Core.Bases;
using Croppilot.Core.Features.Authentication.Queries.Result;
using MediatR;

namespace Croppilot.Core.Features.Authentication.Queries.Models
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
