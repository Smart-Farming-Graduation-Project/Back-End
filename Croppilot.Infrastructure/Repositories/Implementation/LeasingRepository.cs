namespace Croppilot.Infrastructure.Repositories.Implementation
{
    public class LeasingRepository(AppDbContext context)
        : GenericRepository<Leasing>(context), ILeasingRepository
    {
    }
}
