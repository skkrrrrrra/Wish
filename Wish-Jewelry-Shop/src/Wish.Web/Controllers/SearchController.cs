using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wish.Application.Requests.Auth;
using Wish.Application.Responses.Auth;
using Wish.Application.Responses.Product;
using Wish.Application.Services;
using Wish.Application.Services.Interfaces;
using Wish.Domain.Entities;

namespace Wish.Web.Controllers
{
	[ApiController]
	[Route("api/search")]
	public class SearchController : ControllerBase
	{
		private readonly ISearchService _searchService;

		public SearchController(ISearchService searchService)
		{
            _searchService = searchService;
		}

		[HttpGet("{s}"), AllowAnonymous]
		public async Task<Result<IEnumerable<ProductResponse>>> Search([FromRoute] string s, CancellationToken cancellationToken)
		{
			var result = await _searchService.GetItemsWhatContains(s, cancellationToken);

			return result;
		}
	}
}
