using Croppilot.Date.Models;
using Croppilot.Infrastructure.Comman;

namespace Croppilot.Services.Abstract;

public interface IRoverService
{
    Task<OperationResult> CreateRoverAsync(Rover rover, CancellationToken cancellationToken = default);
    Task<IEnumerable<Rover>> GetRoversByUserIdAsync(string userId, CancellationToken cancellationToken = default);
    Task<Rover?> GetRoverByIdAsync(string roverId, CancellationToken cancellationToken = default);
    Task<bool> DeleteRoverAsync(string roverId, CancellationToken cancellationToken = default);
} 