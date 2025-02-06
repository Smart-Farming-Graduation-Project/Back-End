using Croppilot.Core.Features.Category.Command.Models;
using Croppilot.Services.Abstract;

namespace Croppilot.Core.Features.Category.Command.Handlers
{
    public class CategoryCommandHandlers(ICategoryService categoryService) : ResponseHandler,
        IRequestHandler<AddCategoryCommand, Response<string>>
        , IRequestHandler<DeleteCategoryCommand, Response<string>>,
        IRequestHandler<EditCategoryCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await categoryService.GetByNameAsync(command.Name);
            if (category != null)
            {
                return BadRequest<string>("This Category Name Is Already Exist");
            }
            category = new Date.Models.Category
            {
                Name = command.Name,
                Description = command.Description
            };
            var result = await categoryService.CreateAsync(category, cancellationToken);
            return result is OperationResult.Success ? Created("Category Added Successfully") : BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await categoryService.DeleteAsync(request.Id, cancellationToken);
            return result ? Deleted<string>($"Category {request.Id} Deleted Successfully") : BadRequest<string>("Category Not Found");

        }

        public async Task<Response<string>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await categoryService.GetByIdAsync(request.Id, cancellationToken: cancellationToken);
            if (category == null)
            {
                return NotFound<string>("Category Not Found");
            }
            // Check if another category with the same name already exists
            var existingCategory = await categoryService.GetByNameAsync(request.Name);
            if (existingCategory != null && existingCategory.Id != request.Id)
            {
                return BadRequest<string>("Another Category With This Name Already Exists");
            }
            category.Name = request.Name;
            category.Description = request.Description;

            var result = await categoryService.UpdateAsync(category, cancellationToken);
            return result is OperationResult.Success ? Success("Category Updated Successfully") : BadRequest<string>("Failed to Update Category");
        }
    }
}
