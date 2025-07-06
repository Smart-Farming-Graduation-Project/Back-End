namespace Croppilot.Date.Helpers;

public class RedisSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string InstanceName { get; set; } = string.Empty;
    public TimeSpan DefaultExpiration { get; set; } = TimeSpan.FromHours(1);
    public TimeSpan LongTermExpiration { get; set; } = TimeSpan.FromDays(1);
    public TimeSpan ShortTermExpiration { get; set; } = TimeSpan.FromMinutes(15);
} 