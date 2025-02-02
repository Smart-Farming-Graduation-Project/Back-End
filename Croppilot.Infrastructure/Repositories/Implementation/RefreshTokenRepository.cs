using Croppilot.Date.Identity;
using Croppilot.Infrastructure.Generics.Implementation;

namespace Croppilot.Infrastructure.Repositories.Implementation
{
	internal class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
	{
		public RefreshTokenRepository(AppDbContext context) : base(context) { }
	}
}
