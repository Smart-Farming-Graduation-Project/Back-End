using Croppilot.Date.Models.AiModel;
using Croppilot.Infrastructure.Repositories.Interfaces.AiRepository;

namespace Croppilot.Infrastructure.Repositories.Implementation.AiRepository
{
    public class FeedbackRepository(AppDbContext context) : GenericRepository<FeedbackEntry>(context), IFeedbackRepository
    {
    }
}
