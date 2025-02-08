using Croppilot.Infrastructure.Generics.Implementation;

namespace Croppilot.Infrastructure.Repositories.Implementation;

public class OrderRepository(AppDbContext context)
    : GenericRepository<Order>(context), IOrderRepository;