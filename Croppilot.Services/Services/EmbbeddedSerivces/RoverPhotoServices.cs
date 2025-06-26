using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Croppilot.Services.Abstract.EmbbeddedServices;
using Microsoft.Extensions.Configuration;

namespace Croppilot.Services.Services.EmbbeddedSerivces
{
    public class RoverPhotoServices : IRoverPhotoServices
    {
        public BlobServiceClient Client { get; }

        public RoverPhotoServices(IConfiguration configuration)
        {
            var connStr = configuration["AzureKey:RoverStorge"];
            Client = new BlobServiceClient(connStr);
        }

        public async Task<string> UploadImageAsync(Stream imageStream, string blobName)
        {
            BlobContainerClient containerClient;

            if (blobName.Contains("cropguardrover", StringComparison.OrdinalIgnoreCase))
            {
                containerClient = Client.GetBlobContainerClient("rover-predicted-photo");
            }
            else
            {
                containerClient = Client.GetBlobContainerClient("other-predicted-photo");
            }

            await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(imageStream, overwrite: true);

            return blobClient.Uri.ToString();
        }
        public async Task<List<Uri>> GetAllImageUrisWithNoAiAsync()
        {
            var containerClient = Client.GetBlobContainerClient("rover-pohotes");
            var imageUris = new List<Uri>();
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                if (blobItem.Name.Contains("cropguardrover", StringComparison.OrdinalIgnoreCase) &&
                    IsImageFile(blobItem.Name))
                {
                    var blobClient = containerClient.GetBlobClient(blobItem.Name);
                    imageUris.Add(blobClient.Uri);
                }
            }
            return imageUris;
        }
        public async Task<List<Uri>> GetAllImageUrisWithAiAsync()
        {
            var containerClient = Client.GetBlobContainerClient("rover-predicted-photo");
            var imageUris = new List<Uri>();
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                if (blobItem.Name.Contains("cropguardrover", StringComparison.OrdinalIgnoreCase) &&
                    IsImageFile(blobItem.Name))
                {
                    var blobClient = containerClient.GetBlobClient(blobItem.Name);
                    imageUris.Add(blobClient.Uri);
                }
            }
            return imageUris;
        }
        private bool IsImageFile(string fileName)
        {
            string[] imageExtensions = { ".jpg", ".jpeg", ".png" };
            return imageExtensions.Any(ext => fileName.EndsWith(ext, StringComparison.OrdinalIgnoreCase));
        }
    }
}
