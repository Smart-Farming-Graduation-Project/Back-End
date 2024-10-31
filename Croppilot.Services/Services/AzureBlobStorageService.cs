using Azure.Storage;
using Azure.Storage.Blobs;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Croppilot.Services.Services
{
	internal class AzureBlobStorageService : IAzureBlobStorageService
	{
		private readonly BlobContainerClient _containerClient;
        public AzureBlobStorageService(IConfiguration configuration)
        {
			_containerClient = new BlobServiceClient(
				new Uri($"https://{configuration.GetSection("AzureKey:StorageAccount").Value}.blob.core.windows.net"),
				new StorageSharedKeyCredential(configuration.GetSection("AzureKey:StorageAccount").Value, configuration.GetSection("AzureKey:ConnectionString").Value))
				.GetBlobContainerClient(configuration.GetSection("AzureKey:ContainerName").Value);
		}
        public async Task<bool> DeleteImageAsync(string filaName)
		{
			try
			{
				var blob = _containerClient.GetBlobClient(filaName);
				if(await blob.ExistsAsync())
				{
					await blob.DeleteAsync();
					return true;
				}
				return false;
			}
			catch(Exception e)
			{
				throw;
			}
		}

		public async Task<string> UploadImageAsync(IFormFile file)
		{
			try
			{
				var blob = _containerClient.GetBlobClient(file.FileName);
				await using (var stream = file.OpenReadStream())
				{
					await blob.UploadAsync(stream);
				}
				return blob.Uri.AbsoluteUri;
			}
			catch(Exception e)
			{
				throw;
			}
		}
	}
}
