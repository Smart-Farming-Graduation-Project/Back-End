using Croppilot.Infrastructure.Generics.Implementation;

namespace Croppilot.Infrastructure.Repositories.Implementation;

public class CartRepository(AppDbContext context) : GenericRepository<Cart>(context), ICartRepository;