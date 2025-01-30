using Croppilot.Core.Bases;
using Croppilot.Core.Featuers.Product.Query.Models;
using MediatR;

namespace Croppilot.Core.Featuers.Product.Query.Result
{
    public class GetProductByIdResponse : IRequest<Response<GetProductByIdQueryy>>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Availability { get; set; }
        public List<string> Images { get; set; }
    }
}
