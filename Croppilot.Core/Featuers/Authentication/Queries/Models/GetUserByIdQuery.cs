using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Authentication.Queries.Result;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Queries.Models
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
