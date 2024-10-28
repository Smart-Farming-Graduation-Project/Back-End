using Croppilot.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Croppilot.Core.Featuers.Product.Query.GetProduct
{
    public class GetAllProductHandlers(IUnitOfWork unit) : IRequestHandler<GetAllProductQuery, Date.Models.Product>
    {
        public Task<Date.Models.Product> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
