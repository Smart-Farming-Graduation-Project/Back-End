using Croppilot.Infrastructure.Repositories.Interfaces;

namespace Croppilot.Services.Services
{
	class CuponService(IUnitOfWork unitOfWork) : ICuponService
	{
		public async Task<OperationResult> CreateCuponAsync(Cupon cupon)
		{
			await unitOfWork.CuponRepository.AddAsync(cupon);
			return OperationResult.Success;
		}

		public async Task<Cupon?> GetCuponByCodeAsync(string code, string[]? includeProperties = null, bool tracked = false)
		{
			return await unitOfWork.CuponRepository
				.GetAsync(x => x.Code == code, includeProperties: includeProperties, tracked: tracked);
		}

		public async Task<Cupon?> GetCuponByIdAsync(int id, string[]? includeProperties = null)
		{
			return await unitOfWork.CuponRepository
				.GetAsync(x => x.Id == id, includeProperties);
		}

		public async Task<bool> IsUniqueCode(string cuponCode)
		{
			return
				await unitOfWork.CuponRepository
				.GetAsync(c => c.Code.Trim() == cuponCode.Trim() && !c.IsDeleted) == null;
		}
	}
}
