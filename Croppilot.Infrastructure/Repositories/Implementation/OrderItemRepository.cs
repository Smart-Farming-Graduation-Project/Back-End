using Croppilot.Infrastructure.Generics.Implementation;

namespace Croppilot.Infrastructure.Repositories.Implementation;

// todo : i think we don't need this OrderItemRepository , and IOrderItemRepository will remove it later if no needed
public class OrderItemRepository(AppDbContext context)
    : GenericRepository<OrderItem>(context), IOrderItemRepository;