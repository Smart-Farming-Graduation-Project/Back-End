namespace Croppilot.Services.Abstract
{
    public interface IAzureBlobStorageService
    {
        Task<List<string>> UploadImagesAsync(List<string> files, string? fileName);
        Task<string> UploadImagesAsync(string oldImageUrl, string newFilePath, string productName);
        Task<bool> DeleteImageAsync(string filaName);
    }
}