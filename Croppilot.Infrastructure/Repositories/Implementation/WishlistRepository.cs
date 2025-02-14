namespace Croppilot.Infrastructure.Repositories.Implementation;

public class WishlistRepository(AppDbContext context) : GenericRepository<Wishlist>(context), IWishlistRepository;