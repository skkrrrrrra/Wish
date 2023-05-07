using Wish.Application.Responses.CartshopItems;
using Wish.Application.Responses.Product;
using Wish.Domain.Entities;

namespace Wish.Application.Services.Interfaces
{
	public interface ICartshopService
	{
		public Task<Result<string>> AddToCartshopAsync(long id, CancellationToken cancellationToken);
		public Task<Result<string>> RemoveFromCartshop(long id, CancellationToken cancellationToken);
		public Task<Result<IEnumerable<OrderItem>>> GetCartshopItems(int pageNumber, int pageSize, CancellationToken cancellationToken);
        public Task<Result<string>> BuyAllFromCartshopAsync(CancellationToken cancellationToken);
		public Task<Result<IEnumerable<OrderItem>>> GetMyCompleteOrdersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);

    }
}
