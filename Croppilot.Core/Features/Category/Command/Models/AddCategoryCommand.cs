namespace Croppilot.Core.Features.Category.Command.Models
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
