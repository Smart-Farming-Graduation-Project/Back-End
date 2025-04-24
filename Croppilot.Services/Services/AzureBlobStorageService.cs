using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Croppilot.Services.Services
{
	public class AzureBlobStorageService(BlobServiceClient client) : IAzureBlobStorageService
	{

		private readonly string containerName = "product-images";



		public async Task<List<string>> UploadImagesAsync(List<string> filePaths, string? imageNamePrefix)
		{
			var uploadedUrls = new List<string>();
			var container = client.GetBlobContainerClient(containerName);
			await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

			foreach (var filePath in filePaths)
			{
				var fileName = Path.GetFileName(filePath);
				var blobName = $"{imageNamePrefix}_{Path.GetFileNameWithoutExtension(fileName)}{Path.GetExtension(fileName)}";

				using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
				var blobClient = container.GetBlobClient(blobName);
				await blobClient.UploadAsync(stream, overwrite: true);

				uploadedUrls.Add(blobClient.Uri.ToString());
			}

			return uploadedUrls;
		}


		public async Task<string> UploadImageAsync(Stream imageStream, string containerName, string blobName)
		{
			var containerClient = client.GetBlobContainerClient(containerName);
			await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

			var blobClient = containerClient.GetBlobClient(blobName);
			await blobClient.UploadAsync(imageStream, overwrite: true);

			return blobClient.Uri.ToString();
		}



		public async Task<string> UploadImagesAsync(string oldImageUrl, string newFilePath, string productName)
		{

			var container = client.GetBlobContainerClient(containerName);
			await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

			// Extract blob name from old image URL
			var oldBlobName = oldImageUrl.Split('/').Last();
			var oldBlobClient = container.GetBlobClient(oldBlobName);

			// Delete old image from Azure
			await oldBlobClient.DeleteIfExistsAsync();

			// Upload new image to Azure
			var newFileName = Path.GetFileName(newFilePath);
			var newBlobName = $"{productName}_{Path.GetFileNameWithoutExtension(newFileName)}{Path.GetExtension(newFileName)}";
			var newBlobClient = container.GetBlobClient(newBlobName);
			using var stream = new FileStream(newFilePath, FileMode.Open, FileAccess.Read);
			await newBlobClient.UploadAsync(stream, overwrite: true);

			return newBlobClient.Uri.ToString();

		}


		public async Task<bool> DeleteImageAsync(string fileName)
		{
			var blobContainerClient = client.GetBlobContainerClient(containerName);
			var blobClient = blobContainerClient.GetBlobClient(fileName);
			await blobClient.DeleteIfExistsAsync();
			return true;
		}
	}
}
