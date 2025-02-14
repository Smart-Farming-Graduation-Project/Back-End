using Croppilot.Date.Identity;

namespace Croppilot.Infrastructure.Repositories.Implementation
{
	internal class RefreshTokenRepository(AppDbContext context)
		: GenericRepository<RefreshToken>(context), IRefreshTokenRepository;
}
