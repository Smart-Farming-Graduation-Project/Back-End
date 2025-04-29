using Croppilot.Date.DTOS;
using Croppilot.Services.Abstract;

namespace Croppilot.API.Controller;

[Route("api/[controller]"), ApiController]
public class TestController(
	IProductServices _productServices,
	IEmailService emailService,
	IAuthenticationService _authenticationService,
	IAzureBlobStorageService azureBlobStorageService,
	IProductImageServices productImageServices,
	ICategoryService categoryService)
	: ControllerBase
{
	[HttpPost("send-test")]
	public async Task<IActionResult> SendTestEmail([FromBody] EmailSendDto emailSend)
	{
		if (emailSend == null || string.IsNullOrEmpty(emailSend.To))
		{
			return BadRequest("Invalid email data.");
		}

		bool isSuccess = await emailService.SendEmailAsync(emailSend);

		if (isSuccess)
		{
			return Ok(new { message = "Email sent successfully!" });
		}
		else
		{
			return StatusCode(500, new { error = "Failed to send email." });
		}
	}

	[HttpGet("test")]
	[EnableRateLimiting(RateLimiters.IpRateLimit)]
	public IActionResult Test()
	{
		return Ok("Test endpoint is working!");
	}

	//[HttpGet("ProductList")]
	//public async Task<IActionResult> GetProduct()
	//{
	//	var products = await _productServices.GetAll(includeProperties: ["Category"], cancellationToken: default);
	//	return Ok(products);
	//}

	//[HttpGet("{id}")]
	//public async Task<ActionResult<Product?>> GetProductById(int id, string[]? includeProperties = null, CancellationToken cancellationToken = default)
	//{
	//	var product = await _productServices.GetByIdAsync(id, includeProperties, cancellationToken);
	//	if (product == null)
	//	{
	//		return NotFound();
	//	}
	//	return Ok(product);
	//}
	//[HttpPost]
	//public async Task<IActionResult> CreateProduct(CreateProductDTO product, CancellationToken cancellationToken = default)
	//{
	//    await _productServices.CreateAsync(product, cancellationToken);
	//    return Ok();
	//}
	//[HttpPut("{id}")]
	//public async Task<IActionResult> UpdateProduct(int id, UpdateProductDTO product, CancellationToken cancellationToken = default)
	//{
	//    await _productServices.UpdateAsync(id, product, cancellationToken);
	//    return Ok();
	//}
	//[HttpDelete("{id}")]
	//public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken = default)
	//{
	//	await _productServices.Delete(id, cancellationToken);
	//	return Ok();
	//}

	//[HttpGet("GetRefreshToken")]
	//public async Task<IActionResult> GetRefreshToken()
	//{
	//	return Ok(await _authenticationService.GetRefreshTokens());
	//}

	[HttpPost("AddImageToProduct")]
	public async Task<IActionResult> AddImageToProduct([FromForm] List<IFormFile> images, int id)
	{
		// Assuming you have a method to handle the image upload
		var product = await _productServices.GetByIdAsync(id);
		var productName = product.Name;
		var tempFilePaths = await productImageServices.SaveFilesTemporarily(images);
		var result = await azureBlobStorageService.UploadImagesAsync(tempFilePaths, productName);
		return Ok(result);
	}
	[HttpPost("AddImageToCategory")]
	public async Task<IActionResult> AddImageToCategory([FromForm] CategoryImage categoryImage)
	{
		// Assuming you have a method to handle the image upload
		var category = await categoryService.GetByIdAsync(categoryImage.id);
		var result = await azureBlobStorageService.UploadImageAsync(categoryImage.image.OpenReadStream(), "category-images", $"{Guid.NewGuid().ToString()}_{category.Name}{Path.GetExtension(categoryImage.image.FileName)}");
		return Ok(result);
	}
}

public class CategoryImage
{
	public int id { get; set; }
	public IFormFile image { get; set; }
}