namespace Croppilot.Infrastructure.Repositories.Implementation
{
	class CuponRepository(AppDbContext context) : GenericRepository<Cupon>(context), ICuponRepository
	{
	}
}
