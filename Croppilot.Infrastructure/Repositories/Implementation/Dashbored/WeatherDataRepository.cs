using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;

namespace Croppilot.Infrastructure.Repositories.Implementation.Dashbored
{
    public class WeatherDataRepository(AppDbContext context) : GenericRepository<WeatherData>(context), IWeatherDataRepository
    {
        public async Task<WeatherData?> GetLastRecord()
        {
            return await context.WeatherDatas
                .OrderByDescending(w => w.Id)
                .FirstOrDefaultAsync();
        }
    }
}
