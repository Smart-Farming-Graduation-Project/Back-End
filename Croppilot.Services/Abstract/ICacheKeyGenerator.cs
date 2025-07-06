namespace Croppilot.Services.Abstract;

public interface ICacheKeyGenerator
{
    /// <summary>
    /// Generates a cache key for a specific entity by ID
    /// </summary>
    /// <param name="entityName">Name of the entity</param>
    /// <param name="id">Entity ID</param>
    /// <returns>Formatted cache key</returns>
    string GenerateKey(string entityName, object id);

    /// <summary>
    /// Generates a cache key for a collection with optional parameters
    /// </summary>
    /// <param name="entityName">Name of the entity collection</param>
    /// <param name="parameters">Additional parameters for the key</param>
    /// <returns>Formatted cache key</returns>
    string GenerateCollectionKey(string entityName, params object[] parameters);

    /// <summary>
    /// Generates a cache key for user-specific data
    /// </summary>
    /// <param name="userId">User ID</param>
    /// <param name="dataType">Type of user data</param>
    /// <param name="additionalParams">Additional parameters</param>
    /// <returns>Formatted cache key</returns>
    string GenerateUserKey(string userId, string dataType, params object[] additionalParams);

    /// <summary>
    /// Generates a cache key for paginated results
    /// </summary>
    /// <param name="entityName">Name of the entity</param>
    /// <param name="pageNumber">Page number</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="additionalParams">Additional parameters for filtering</param>
    /// <returns>Formatted cache key</returns>
    string GeneratePaginatedKey(string entityName, int pageNumber, int pageSize, params object[] additionalParams);

    /// <summary>
    /// Generates a pattern for cache invalidation
    /// </summary>
    /// <param name="entityName">Name of the entity</param>
    /// <returns>Pattern for key matching</returns>
    string GeneratePattern(string entityName);
} 