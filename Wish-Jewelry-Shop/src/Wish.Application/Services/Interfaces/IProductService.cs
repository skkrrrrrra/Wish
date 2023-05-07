using Wish.Application.Responses.Product;
using Wish.Domain.Entities;

namespace Wish.Application.Services.Interfaces
{
	public interface IProductService
	{
		public Task<Result<ProductResponse>> GetByIdAsync(long categoryId, long id, CancellationToken cancellationToken);
		public Task<Result<IEnumerable<ProductResponse>>> GetAllItemsAsync(int pageNumber, int pageSize, long categoryId, CancellationToken cancellationToken);
	}
}
