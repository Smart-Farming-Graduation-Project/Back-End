using Croppilot.Core.Features.User.Queries.Result;

namespace Croppilot.Core.Features.User.Queries.Models
{
    public class GetUserPaginatedQuery : IRequest<Response<List<GetUser>>>
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
