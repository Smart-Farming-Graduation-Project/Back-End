using Microsoft.AspNetCore.Http;

namespace Croppilot.Services.Abstract
{
    public interface IAzureBlobStorageService
    {
        Task<List<string>> UploadImagesAsync(List<IFormFile> files, string? fileName);
        Task<bool> DeleteImageAsync(string filaName);
    }
}
