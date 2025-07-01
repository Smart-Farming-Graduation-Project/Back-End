namespace Croppilot.Core.Features.Product.Query.Models
{
	public class GetProductsByUserId : IRequest<Response<List<GetProductPaginatedResponse>>>
	{
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 10;
	}
}
