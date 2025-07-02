using System.Security.Cryptography;
using System.Text;

namespace Croppilot.Services.Services;

public class CacheKeyGenerator : ICacheKeyGenerator
{
    private const string SEPARATOR = ":";
    private const string COLLECTION_SUFFIX = "collection";
    private const string USER_PREFIX = "user";
    private const string PAGINATED_SUFFIX = "page";

    public string GenerateKey(string entityName, object id)
    {
        return $"{entityName.ToLowerInvariant()}{SEPARATOR}{id}";
    }

    public string GenerateCollectionKey(string entityName, params object[] parameters)
    {
        var keyParts = new List<string>
        {
            entityName.ToLowerInvariant(),
            COLLECTION_SUFFIX
        };

        if (parameters.Length <= 0) 
            return string.Join(SEPARATOR, keyParts);
        
        var parameterHash = GenerateParameterHash(parameters);
        keyParts.Add(parameterHash);

        return string.Join(SEPARATOR, keyParts);
    }

    public string GenerateUserKey(string userId, string dataType, params object[] additionalParams)
    {
        var keyParts = new List<string>
        {
            USER_PREFIX,
            userId,
            dataType.ToLowerInvariant()
        };

        if (additionalParams.Length <= 0)
            return string.Join(SEPARATOR, keyParts);
        
        var parameterHash = GenerateParameterHash(additionalParams);
        keyParts.Add(parameterHash);

        return string.Join(SEPARATOR, keyParts);
    }

    public string GeneratePaginatedKey(string entityName, int pageNumber, int pageSize, params object[] additionalParams)
    {
        var keyParts = new List<string>
        {
            entityName.ToLowerInvariant(),
            PAGINATED_SUFFIX,
            pageNumber.ToString(),
            pageSize.ToString()
        };

        if (additionalParams.Length <= 0)
            return string.Join(SEPARATOR, keyParts);
        
        var parameterHash = GenerateParameterHash(additionalParams);
        keyParts.Add(parameterHash);

        return string.Join(SEPARATOR, keyParts);
    }

    public string GeneratePattern(string entityName)
    {
        return $"{entityName.ToLowerInvariant()}{SEPARATOR}*";
    }

    private static string GenerateParameterHash(object[] parameters)
    {
        var parameterString = string.Join("|", parameters.Select(p => p?.ToString() ?? "null"));
        return ComputeHash(parameterString);
    }

    private static string ComputeHash(string input)
    {
        var bytes = Encoding.UTF8.GetBytes(input);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash)[..8]; // Take the first 8 characters for shorter keys
    }
} 