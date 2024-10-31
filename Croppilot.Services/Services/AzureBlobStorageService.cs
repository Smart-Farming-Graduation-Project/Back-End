using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Http;

namespace Croppilot.Services.Services
{
    public class AzureBlobStorageService(BlobServiceClient client) : IAzureBlobStorageService
    {

        private readonly BlobServiceClient blobServiceClient;
        private readonly string containerName = "product-images";



        public async Task<List<string>> UploadImagesAsync(List<IFormFile> files, string? imageNamePrefix)
        {
            var uploadedUrls = new List<string>();
            var container = client.GetBlobContainerClient(containerName);
            await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

            foreach (var file in files)
            {
                var blobName = $"{imageNamePrefix}_{Path.GetFileNameWithoutExtension(file.FileName)}{Path.GetExtension(file.FileName)}";

                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var blobClient = container.GetBlobClient(blobName);
                await blobClient.UploadAsync(memoryStream, overwrite: true);

                uploadedUrls.Add(blobClient.Uri.ToString());
            }

            return uploadedUrls;
        }


        public async Task<bool> DeleteImageAsync(string fileName)
        {
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
            return true;
        }

    }
}
