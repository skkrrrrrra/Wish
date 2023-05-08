using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wish.Application.Responses.Product;
using Wish.Application.Services.Interfaces;
using Wish.Domain.Entities;

namespace Wish.Web.Controllers
{
	[ApiController]
	[Route("api/catalog")]
	[Authorize]
	public class CatalogController : ControllerBase
	{
		private readonly IProductService _productService;
		public CatalogController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("product/{id}"), AllowAnonymous]
		public async Task<Result<ProductResponse>> GetItem([FromRoute] long id, CancellationToken cancellationToken)
		{
			var result = await _productService.GetByIdAsync(id, cancellationToken);
			return result;
		}

		[HttpGet("{categoryId}"), AllowAnonymous]
		public async Task<Result<IEnumerable<ProductResponse>>> GetAllItems([FromQuery]int pageNumber,[FromQuery] int pageSize, [FromRoute] long categoryId, CancellationToken cancellationToken)
		{
			var result = await _productService.GetAllItemsAsync(pageNumber, pageSize, categoryId, cancellationToken);
			return result;
		}
    }
}
