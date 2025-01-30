using Croppilot.Core.Bases;
using MediatR;

namespace Croppilot.Core.Featuers.Category.Command.Models
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }

        public string Description { get; set; }

    }
}
