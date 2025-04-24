using Croppilot.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Croppilot.Services.Services
{
	public class ProductImageServices(IUnitOfWork unit, IAzureBlobStorageService azureBlobStorageService)
		: IProductImageServices
	{
		public async Task<List<ProductImage>> GetByProductIdAsync(int productId,
			CancellationToken cancellationToken = default)
		{
			var productImages = await unit.ProductImageRepository.GetAllAsync(x => x.ProductId == productId,
				tracked: false, cancellationToken: cancellationToken);
			return productImages;
		}


		public async Task UploadImagesAndUpdateProduct(int productId, List<string> filePaths, string productName)
		{
			// Upload images to Azure
			var imageUrls = await azureBlobStorageService.UploadImagesAsync(filePaths, productName);

			// Fetch the product
			var product = await unit.ProductRepository.GetProductsById(productId);
			if (product is null) throw new Exception($"Product with ID {productId} not found");

			// Add image URLs to product
			var productImages = imageUrls.Select(url => new ProductImage
			{
				ImageUrl = url,
				ProductId = productId
			}).ToList();

			foreach (var productImage in productImages)
			{
				await unit.ProductImageRepository.AddAsync(productImage);
			}

			// Clean up local files
			foreach (var filePath in filePaths)
			{
				File.Delete(filePath);
			}
		}

		public async Task EditImageAsync(int productId, string oldImageUrl, string newFilePath, string productName)
		{

			// Update product image URL in the database
			var product = await unit.ProductRepository.GetProductsById(productId);
			if (product is null) throw new Exception($"Product with ID {productId} not found");

			var productImage = product.ProductImages.FirstOrDefault(img => img.ImageUrl == oldImageUrl);
			if (productImage is null) throw new Exception($"Image not found for product {productId}");

			string imageUrl = await azureBlobStorageService.UploadImagesAsync(oldImageUrl, newFilePath, productName);


			productImage.ImageUrl = imageUrl;
			await unit.ProductImageRepository.UpdateAsync(productImage);

			// Clean up
			File.Delete(newFilePath);
		}
		public async Task DeleteImageAsync(int productId, string imageUrl)
		{
			var product = await unit.ProductRepository.GetProductsById(productId);
			if (product is null) throw new Exception($"Product with ID {productId} not found");

			var productImage = product.ProductImages.FirstOrDefault(img => img.ImageUrl == imageUrl);
			if (productImage is null) throw new Exception($"Image not found for product {productId}");

			await azureBlobStorageService.DeleteImageAsync(imageUrl, "product-images");
			await unit.ProductImageRepository.DeleteAsync(productImage);
		}

		public async Task DeleteImagesAsync(int productId)
		{
			var product = await unit.ProductRepository
				.GetAllAsync(p => p.Id == productId, ["ProductImages"], tracked: false);
			var firstProducr = product.FirstOrDefault();
			if (product is null) throw new Exception($"Product with ID {productId} not found");

			//var imageUrls = product.ProductImages.Select(img => img.ImageUrl).ToList();
			await unit.ProductImageRepository.DeleteRangeAsync(firstProducr.ProductImages);
		}




		public async Task<List<string>> SaveFilesTemporarily(List<IFormFile> files)
		{
			var tempPaths = new List<string>();
			var tempDir = Path.Combine(Path.GetTempPath(), "ProductImages");
			Directory.CreateDirectory(tempDir);

			foreach (var file in files)
			{
				var tempPath = Path.Combine(tempDir, $"{Guid.NewGuid()}_{file.FileName}");
				using (var stream = new FileStream(tempPath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				tempPaths.Add(tempPath);
			}
			return tempPaths;
		}
	}
}
