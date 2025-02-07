using Croppilot.Date.Enum;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services;

public class OrderService(IUnitOfWork unitOfWork) : IOrderService
{
    public async Task<OperationResult> CreateAsync(Order order, CancellationToken cancellationToken = default)
    {
        await unitOfWork.OrderRepository.AddAsync(order, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<Order?> GetByIdAsync(int orderId, string[]? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        return await unitOfWork.OrderRepository.GetAsync(
            o => o.Id == orderId,
            includeProperties,
            cancellationToken: cancellationToken);
    }

    public async Task<List<Order>> GetAllAsync(string[]? includeProperties = null,
        CancellationToken cancellationToken = default)
    {
        return await unitOfWork.OrderRepository
            .GetAllAsync(includeProperties: includeProperties, cancellationToken: cancellationToken);
    }

    public async Task<List<Order>> GetUserOrdersAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await unitOfWork.OrderRepository.GetAllAsync(
            filter: o => o.UserId == userId,
            includeProperties: ["OrderItems", "User"], cancellationToken: cancellationToken);
    }

    public async Task<OperationResult> UpdateAsync(Order order, CancellationToken cancellationToken = default)
    {
        var existingOrder =
            await unitOfWork.OrderRepository.GetAsync(o => o.Id == order.Id, cancellationToken: cancellationToken);
        
        if (existingOrder == null)
            return OperationResult.NotFound;

        await unitOfWork.OrderRepository.UpdateAsync(order, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<bool> DeleteAsync(int orderId, CancellationToken cancellationToken = default)
    {
        var order = await unitOfWork.OrderRepository.GetAsync(o => o.Id == orderId,
            cancellationToken: cancellationToken);
        
        if (order == null)
            return false;

        await unitOfWork.OrderRepository.DeleteAsync(order, cancellationToken);
        return true;
    }
}