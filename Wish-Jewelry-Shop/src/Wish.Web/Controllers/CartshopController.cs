using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wish.Application.Responses.CartshopItems;
using Wish.Application.Responses.Product;
using Wish.Application.Services.Interfaces;
using Wish.Domain.Entities;

namespace Wish.Web.Controllers
{
	[ApiController]
	[Route("api/cartshop")]
	[Authorize]
	public class CartshopController : ControllerBase
	{
		private readonly ICartshopService _cartshopService;
		public CartshopController(ICartshopService cartshopService)
		{
			_cartshopService = cartshopService;
		}
		[HttpPost("add"), Authorize]
		public async Task<Result<string>> AddItemToCartshop([FromBody] long id, CancellationToken cancellationToken)
		{
			var result = await _cartshopService.AddToCartshopAsync(id, cancellationToken);
			return result;
		}
		[HttpDelete("{id}"), Authorize]
		public async Task<Result<string>> RemoveItemFromCartshop([FromRoute] long id, CancellationToken cancellationToken)
		{
			var result = await _cartshopService.RemoveFromCartshop(id, cancellationToken);
			return result;
		}
		[HttpGet, Authorize]
		public async Task<Result<IEnumerable<OrderItem>>> GetCartshopItems([FromQuery]int pageNumber,[FromQuery] int pageSize, CancellationToken cancellationToken)
		{
			var result = await _cartshopService.GetCartshopItems(pageNumber, pageSize, cancellationToken);
			return result;
		}
		[HttpPost("buy"), Authorize]
		public async Task<Result<string>> BuyAll(CancellationToken cancellationToken)
		{
			var result = await _cartshopService.BuyAllFromCartshopAsync(cancellationToken);
			return result;
		}
		[HttpGet("completed"), Authorize]
		public async Task<Result<IEnumerable<OrderItem>>> GetCompleteOrders([FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken cancellationToken)
		{
			var result = await _cartshopService.GetMyCompleteOrdersAsync(pageNumber, pageSize, cancellationToken);
			return result;
		}
	}
}
