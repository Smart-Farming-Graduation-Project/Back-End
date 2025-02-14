namespace Croppilot.Infrastructure.Repositories.Implementation;

public class OrderRepository(AppDbContext context)
    : GenericRepository<Order>(context), IOrderRepository;