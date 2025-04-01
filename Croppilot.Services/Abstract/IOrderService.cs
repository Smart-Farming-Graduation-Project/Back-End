namespace Croppilot.Services.Abstract;

public interface IOrderService
{
	Task<OperationResult> CreateAsync(Order order, CancellationToken cancellationToken = default);

	Task<Order?> GetByIdAsync(int orderId, string[]? includeProperties = null,
		CancellationToken cancellationToken = default);

	Task<List<Order>> GetAllAsync(string[]? includeProperties = null,
		CancellationToken cancellationToken = default);

	Task<List<Order>> GetUserOrdersAsync(string userId, CancellationToken cancellationToken = default);


	Task<OperationResult> UpdateAsync(Order order, CancellationToken cancellationToken = default);

	Task<bool> DeleteAsync(int orderId, CancellationToken cancellationToken = default);
	Task<OperationResult> UpdateOrderStatus(int orderId, OrderStatus status, CancellationToken cancellationToken = default);
}