using Croppilot.Date.Models;
using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Infrastructure.Repositories.Implementation;

public class RoverRepository(AppDbContext context) : GenericRepository<Rover>(context), IRoverRepository
{
} 