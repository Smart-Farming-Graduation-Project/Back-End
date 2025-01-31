using Croppilot.Date.Enum;
using Microsoft.AspNetCore.Http;

namespace Croppilot.Date.DTOS.Product
{
    public class UpdateProductDTO
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
