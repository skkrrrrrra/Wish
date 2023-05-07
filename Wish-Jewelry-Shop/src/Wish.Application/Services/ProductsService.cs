using Microsoft.EntityFrameworkCore;
using Wish.Application.Responses;
using Wish.Application.Responses.Product;
using Wish.Application.Responses.Results;
using Wish.Application.Services.Interfaces;
using Wish.Domain.Entities;
using Wish.Persistence;

namespace Wish.Application.Services
{
	public class ProductService : IProductService
	{
		private readonly MainDbContext _dbContext;
		public ProductService(MainDbContext context)
		{
			_dbContext = context;
		}

		public async Task<Result<ProductResponse>> GetByIdAsync(long categoryId, long productId, CancellationToken cancellationToken)
		{
			var product = await _dbContext.Products.AsNoTracking()
                .Include(p => p.Attributes)
                .Include(p => p.Material)
                .FirstOrDefaultAsync(p => p.Id == productId && p.CategoryId == categoryId, cancellationToken);

			if (product is null)
				return new InvalidResult<ProductResponse>("Товара не существует");

            ProductResponse result = new();
			result.MapFrom(product);
			return new SuccessResult<ProductResponse>(result);
		}
		public async Task<Result<IEnumerable<ProductResponse>>> GetAllItemsAsync(int pageNumber, int pageSize, long categoryId, CancellationToken cancellationToken)
		{
			var products = await _dbContext.Products.AsNoTracking()
				.Where(p => p.CategoryId == categoryId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductResponse {
					Id = p.Id,
					Title = p.Title,
					Description = p.Description,
					PictureImage = p.PictureImage,
					Price = p.Price,
					CategoryId= categoryId,
					Count= p.Count,
					Weight = p.Weight,
				})
				.ToListAsync(cancellationToken);

			if (products is null)
			{
				return new InvalidResult<IEnumerable<ProductResponse>>("Список товаров пуст");
			}
			return new SuccessResult<IEnumerable<ProductResponse>>(products);
		}
	}
}
