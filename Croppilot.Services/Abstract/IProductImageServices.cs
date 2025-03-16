using Microsoft.AspNetCore.Http;

namespace Croppilot.Services.Abstract
{
    public interface IProductImageServices
    {
        Task<List<ProductImage>> GetByProductIdAsync(int productId, CancellationToken cancellationToken = default);
        Task UploadImagesAndUpdateProduct(int productId, List<string> imageUrls, string productName);
        Task EditImageAsync(int productId, string oldImageUrl, string newFilePath, string productName);
        Task DeleteImageAsync(int productId, string imageUrl);
        Task DeleteImagesAsync(int productId);
        Task<List<string>> SaveFilesTemporarily(List<IFormFile> files);
    }
}
