using Croppilot.Date.Models.DashboardModels;
using Croppilot.Infrastructure.Repositories.Interfaces.Dashbored;

namespace Croppilot.Infrastructure.Repositories.Implementation.Dashbored
{
    public class WeatherForcastRepository(AppDbContext context) : GenericRepository<WeatherForecast>(context), IWeatherForcastRepository
    {
    }
}
