using Croppilot.Core.Featuers.Authentication.Queries.Result;
using Croppilot.Infrastructure.Comman;
using MediatR;

namespace Croppilot.Core.Featuers.Authentication.Queries.Models
{
	public class GetUserPaginatedQuery : IRequest<PaginatedResult<GetUser>>
	{
		public int pageNumber { get; set; }
		public int pageSize { get; set; }
		public GetUserPaginatedQuery() : this(1, 10) { }
		public GetUserPaginatedQuery(int pageNumber, int pageSize)
		{
			this.pageNumber = pageNumber == 0 ? 1 : pageNumber;
			this.pageSize = pageSize == 0 ? 10 : pageSize;
		}
	}
}
