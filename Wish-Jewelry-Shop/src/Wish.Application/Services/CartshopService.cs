using Microsoft.EntityFrameworkCore;
using Wish.Application.Responses.CartshopItems;
using Wish.Application.Responses.Product;
using Wish.Application.Responses.Results;
using Wish.Application.Services.Interfaces;
using Wish.Domain.Entities;
using Wish.Persistence;
using Wish.Persistence.Common;

namespace Wish.Application.Services
{
	public class CartshopService : ICartshopService
	{
		private readonly MainDbContext _dbContext;
		private readonly IAuditUserProvider _auditUserProvider;
		public CartshopService(MainDbContext context, IAuditUserProvider provider)
		{
			_dbContext = context;
			_auditUserProvider = provider;
		}
		public async Task<Result<string>> AddToCartshopAsync(long id, CancellationToken cancellationToken)
		{
			var currentUserId = _auditUserProvider.GetUserId();
			//смотрим есть ли в корзине уже такой товар со статусом 0(то есть в корзине)
			var record = await _dbContext.Cartshop
				.FirstOrDefaultAsync(p => p.UserId == currentUserId && p.ProductId == id && p.Status == 0, cancellationToken);
			//вытаскиваем заказ с айди который получили
			var productRecord = await _dbContext.Products.AsNoTracking()
				.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
			if(record is null)
			{
				Cartshop cart = new()
				{
					ProductId = id,
					Count = 1,
					UserId = currentUserId,
					Price = productRecord.Price,
					Status = 0
				};
				_dbContext.Cartshop.Add(cart);
				await _dbContext.SaveChangesAsync(cancellationToken);
				return new SuccessResult<string>("Вы добавили продукт в корзину");
			}
			//если такого заказа нет - создаем его с кол-вом товара 1шт
			//если есть - прибавляем к кол-ву еще 1 и увеличиваем цену
			//а так же устанавливаем статус 0
			record.Count++;
			record.Price += productRecord.Price;
			record.Status = 0;
			await _dbContext.SaveChangesAsync(cancellationToken);
			return new SuccessResult<string>("Вы добавили продукт в корзину");
		}
		public async Task<Result<string>> RemoveFromCartshop(long id, CancellationToken cancellationToken)
		{
			var currentUserId = _auditUserProvider.GetUserId();

			var record = await _dbContext.Cartshop
				.FirstOrDefaultAsync(p => p.UserId == currentUserId && p.ProductId == id && p.Status == 0, cancellationToken);

			if (record is null)
			{
				return new InvalidResult<string>("Такой записи нет в корзине");
			}
			_dbContext.Cartshop.Remove(record);
			await _dbContext.SaveChangesAsync(cancellationToken);
			return new SuccessResult<string>("Товар удален");
		}
		public async Task<Result<IEnumerable<OrderItem>>> GetCartshopItems(int pageNumber, int pageSize, CancellationToken cancellationToken)
		{
			var currentUserId = _auditUserProvider.GetUserId();

			var record = await _dbContext.Cartshop.AsNoTracking()
				.Include(p => p.Product)
				.Where(p => p.UserId == currentUserId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new OrderItem
				{
					Id = p.Product.Id,
					Title = p.Product.Title,
					PictureImage = p.Product.PictureImage,
					Price = p.Price,
					Count = p.Count,
				})
				.ToListAsync(cancellationToken);

			if (record is null)
			{
				return new InvalidResult<IEnumerable<OrderItem>>("Корзина пуста");
			}

			return new SuccessResult<IEnumerable<OrderItem>>(record);
		}
		public async Task<Result<string>> BuyAllFromCartshopAsync(CancellationToken cancellationToken)
		{
			var currentUserId = _auditUserProvider.GetUserId();
			var result = await _dbContext.Cartshop
				.Where(p => p.UserId == currentUserId && p.Status == 0)
				.ToListAsync(cancellationToken);

			if(result == null)
			{
				return new InvalidResult<string>("Корзина пуста");
			}
			foreach (var item in result)
			{
				item.Status = 1;
				item.DateTime = DateTime.UtcNow;
			}
			await _dbContext.SaveChangesAsync(cancellationToken);
			return new SuccessResult<string>("Спасибо за покупку");
		}
		public async Task<Result<IEnumerable<OrderItem>>> GetMyCompleteOrdersAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
		{
			var currentUserId = _auditUserProvider.GetUserId();

			var result = await _dbContext.Cartshop
				.Where(p => p.Status == 1 && p.UserId == currentUserId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new OrderItem
				{
					Title = p.Product.Title,
					Count = p.Count,
					PictureImage = p.Product.PictureImage,
					Price = p.Price
				})
				.ToListAsync(cancellationToken);

			if(result == null)
			{
				return new InvalidResult<IEnumerable<OrderItem>>("У вас пока нет завершенных покупок");
			}
			return new SuccessResult<IEnumerable<OrderItem>>(result);
		}


	}
}
