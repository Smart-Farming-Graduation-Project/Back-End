using Croppilot.Date.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text.Json;

namespace Croppilot.Services.Services;

public class CacheService : ICacheService
{
    private readonly IDatabase _database;
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly RedisSettings _redisSettings;
    private readonly ILogger<CacheService> _logger;
    private readonly JsonSerializerOptions _jsonOptions;

    public CacheService(
        IConnectionMultiplexer connectionMultiplexer,
        IOptions<RedisSettings> redisSettings,
        ILogger<CacheService> logger)
    {
        _connectionMultiplexer =
            connectionMultiplexer ?? throw new ArgumentNullException(nameof(connectionMultiplexer));
        _database = _connectionMultiplexer.GetDatabase();
        _redisSettings = redisSettings.Value ?? throw new ArgumentNullException(nameof(redisSettings));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        try
        {
            var cacheKey = GenerateCacheKey(key);
            var cachedValue = await _database.StringGetAsync(cacheKey);

            if (!cachedValue.HasValue)
            {
                _logger.LogDebug("Cache miss for key: {CacheKey}", cacheKey);
                return null;
            }

            _logger.LogDebug("Cache hit for key: {CacheKey}", cacheKey);
            return JsonSerializer.Deserialize<T>(cachedValue!, _jsonOptions);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting cache value for key: {Key}", key);
            return null;
        }
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
    {
        await SetAsync(key, value, _redisSettings.DefaultExpiration, cancellationToken);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expiration,
        CancellationToken cancellationToken = default) where T : class
    {
        try
        {
            var cacheKey = GenerateCacheKey(key);
            var serializedValue = JsonSerializer.Serialize(value, _jsonOptions);

            await _database.StringSetAsync(cacheKey, serializedValue, expiration);
            _logger.LogDebug("Set cache value for key: {CacheKey} with expiration: {Expiration}", cacheKey, expiration);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting cache value for key: {Key}", key);
        }
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        try
        {
            var cacheKey = GenerateCacheKey(key);
            await _database.KeyDeleteAsync(cacheKey);
            _logger.LogDebug("Removed cache key: {CacheKey}", cacheKey);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing cache key: {Key}", key);
        }
    }

    public async Task RemoveByPatternAsync(string pattern, CancellationToken cancellationToken = default)
    {
        try
        {
            var cachePattern = GenerateCacheKey(pattern);
            var endpoints = _connectionMultiplexer.GetEndPoints();

            foreach (var endpoint in endpoints)
            {
                var server = _connectionMultiplexer.GetServer(endpoint);
                var keys = server.Keys(pattern: cachePattern);

                foreach (var key in keys)
                {
                    await _database.KeyDeleteAsync(key);
                }
            }

            _logger.LogDebug("Removed cache keys matching pattern: {Pattern}", cachePattern);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing cache keys by pattern: {Pattern}", pattern);
        }
    }

    public async Task<bool> ExistsAsync(string key, CancellationToken cancellationToken = default)
    {
        try
        {
            var cacheKey = GenerateCacheKey(key);
            return await _database.KeyExistsAsync(cacheKey);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking cache key existence: {Key}", key);
            return false;
        }
    }

    public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T?>> factory, TimeSpan? expiration = null,
        CancellationToken cancellationToken = default) where T : class
    {
        var cachedValue = await GetAsync<T>(key, cancellationToken);

        if (cachedValue is not null)
        {
            return cachedValue;
        }

        try
        {
            var value = await factory();

            if (value is not null)
            {
                var cacheExpiration = expiration ?? _redisSettings.DefaultExpiration;
                await SetAsync(key, value, cacheExpiration, cancellationToken);
            }

            return value;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetOrSetAsync for key: {Key}", key);
            return null;
        }
    }

    private string GenerateCacheKey(string key)
    {
        return $"{_redisSettings.InstanceName}:{key}";
    }
}