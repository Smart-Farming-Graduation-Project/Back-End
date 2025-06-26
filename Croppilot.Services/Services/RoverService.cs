using Croppilot.Date.Models;
using Croppilot.Infrastructure.Comman;
using Croppilot.Infrastructure.Repositories.Interfaces;
using Croppilot.Services.Abstract;

namespace Croppilot.Services.Services;

public class RoverService(IRoverRepository roverRepository) : IRoverService
{
    public async Task<OperationResult> CreateRoverAsync(Rover rover, CancellationToken cancellationToken = default)
    {
        await roverRepository.AddAsync(rover, cancellationToken);
        return OperationResult.Success;
    }

    public async Task<IEnumerable<Rover>> GetRoversByUserIdAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await roverRepository.GetAllAsync(
            filter: r => r.UserId == userId,
            includeProperties: ["User"],
            cancellationToken: cancellationToken);
    }

    public async Task<Rover?> GetRoverByIdAsync(string roverId, CancellationToken cancellationToken = default)
    {
        return await roverRepository.GetAsync(
            filter: r => r.Id == roverId,
            includeProperties: ["User"],
            cancellationToken: cancellationToken);
    }

    public async Task<bool> DeleteRoverAsync(string roverId, CancellationToken cancellationToken = default)
    {
        var rover = await roverRepository.GetAsync(r => r.Id == roverId, cancellationToken: cancellationToken);
        if (rover == null)
            return false;

        await roverRepository.DeleteAsync(rover, cancellationToken);
        return true;
    }
} 