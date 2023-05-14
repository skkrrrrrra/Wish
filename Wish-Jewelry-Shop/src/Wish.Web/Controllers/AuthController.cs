using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wish.Application.Requests.Auth;
using Wish.Application.Responses.Auth;
using Wish.Application.Services;
using Wish.Domain.Entities;

namespace Wish.Web.Controllers
{
	[ApiController]
	[Route("api/auth"), AllowAnonymous]
	public class AuthController : ControllerBase
	{
		private readonly UserAccountManager _userAccountManager;

		public AuthController(UserAccountManager userAccountManager)
		{
			_userAccountManager = userAccountManager;
		}

		[HttpPost("register"), AllowAnonymous]
		public async Task<Result<IdentityResult>> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
		{
			var result = await _userAccountManager.RegisterAsync(request);
			return result;
		}

		[HttpPost("login"), AllowAnonymous]
		public async Task<Result<LoginResponse>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
		{
			var result = await _userAccountManager.LoginAsync(request);
			return result;
		}
	}
}
