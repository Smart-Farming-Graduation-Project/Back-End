using Croppilot.Core.Bases;
using MediatR;

namespace Croppilot.Core.Features.Category.Command.Models
{
    public class EditCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
