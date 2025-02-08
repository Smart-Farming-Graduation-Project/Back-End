using Croppilot.Infrastructure.Generics.Implementation;

namespace Croppilot.Infrastructure.Repositories.Implementation;

// todo : i think we don't need this OrderItemRepository , and IOrderItemRepository will remove it later if no needed
// todo : i say that because i think we not make service for OrderItem it always part of order or their another senario i don't think of it
public class OrderItemRepository(AppDbContext context)
    : GenericRepository<OrderItem>(context), IOrderItemRepository;