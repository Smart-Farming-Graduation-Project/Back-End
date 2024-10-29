using Croppilot.Infrastructure.Generics.Implementation;

namespace Croppilot.Infrastructure.Repositories.Implementation;

public class CategoryRepository(AppDbContext context)
    : GenericRepository<Category>(context), ICategoryRepository
{
    
}