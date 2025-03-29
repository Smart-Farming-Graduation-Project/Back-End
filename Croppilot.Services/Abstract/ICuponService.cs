namespace Croppilot.Services.Abstract
{
	public interface ICuponService
	{
		Task<OperationResult> CreateCuponAsync(Cupon cupon);
		Task<bool> IsUniqueCode(string cuponCode);
		Task<Cupon?> GetCuponByIdAsync(int id, string[]? includeProperties = null);
		Task<Cupon?> GetCuponByCodeAsync(string code, string[]? includeProperties = null, bool tracked = false);
	}
}
