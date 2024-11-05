using Croppilot.Core.Bases;
using Croppilot.Date.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Croppilot.Core.Featuers.Product.Command.Models
{
    public class EditProductCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public Availability Availability { get; set; }

        [ValidateNever]
        public List<IFormFile> Images { get; set; }
    }
}
