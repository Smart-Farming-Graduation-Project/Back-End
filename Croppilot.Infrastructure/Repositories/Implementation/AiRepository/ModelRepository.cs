using Croppilot.Date.Models.AiModel;
using Croppilot.Infrastructure.Repositories.Interfaces.AiRepository;

namespace Croppilot.Infrastructure.Repositories.Implementation.AiRepository
{
    public class ModelRepository(AppDbContext context) : GenericRepository<ModelResult>(context), IModelRepository
    {
    }
}
