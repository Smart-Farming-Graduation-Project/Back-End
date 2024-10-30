using Azure.Storage;
using Azure.Storage.Blobs;
using Croppilot.Services.Abstract;
using Microsoft.AspNetCore.Http;

namespace Croppilot.Services.Services
{
	internal class AzureBlobStorageService : IAzureBlobStorageService
	{
		private const string _key = "DefaultEndpointsProtocol=https;AccountName=elofatest2;AccountKey=WIM8ob5S83hHxxphqbu5BwzEEWH9ptPh3S/Ab3iNQp0/36UsmZB+KLH44ID+PHxoRh30YXFBlzMH+AStg27T9w==;EndpointSuffix=core.windows.net";
		private const string _storageAccount = "elofatest2";
		private const string _containerName = "elofatest26c7fc8ad-9001-40bb-8031-6443179f47e2";
		private readonly BlobContainerClient _containerClient;
        public AzureBlobStorageService()
        {
			_containerClient = new BlobServiceClient(
				new Uri($"https://{_storageAccount}.blob.core.windows.net"),
				new StorageSharedKeyCredential(_storageAccount, _key))
				.GetBlobContainerClient(_containerName);
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
