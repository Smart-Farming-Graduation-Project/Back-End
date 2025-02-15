namespace Croppilot.Infrastructure.Repositories.Implementation;

public class CartRepository(AppDbContext context) : GenericRepository<Cart>(context), ICartRepository;