using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Croppilot.Services.Abstract.EmbbeddedServices;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

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

            var containerClient = Client.GetBlobContainerClient("rover-predicted-photo");

            await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.UploadAsync(imageStream, overwrite: true);

            return blobClient.Uri.ToString();
        }
    }
}
