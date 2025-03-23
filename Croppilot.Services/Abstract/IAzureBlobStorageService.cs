namespace Croppilot.Services.Abstract
{
    public interface IAzureBlobStorageService
    {
        Task<List<string>> UploadImagesAsync(List<string> files, string? fileName);
        Task<string> UploadImageAsync(Stream imageStream, string containerName, string blobName);
        Task<string> UploadImagesAsync(string oldImageUrl, string newFilePath, string productName);
        Task<bool> DeleteImageAsync(string filaName);
    }
}