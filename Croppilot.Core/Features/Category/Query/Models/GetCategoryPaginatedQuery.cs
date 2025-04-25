using Croppilot.Core.Features.Category.Query.Result;

namespace Croppilot.Core.Features.Category.Query.Models
{
    public class GetCategoryPaginatedQuery : IRequest<Response<List<GetCategoryPaginatedResponse>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public CategoryOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }

        //Do not skip this look and learn
        //this for case of product inside category more than the default number of Pagination list "10" 
        public int ProductPageNumber { get; set; } = 1;
        public int ProductPageSize { get; set; } = 10;
    }

}
