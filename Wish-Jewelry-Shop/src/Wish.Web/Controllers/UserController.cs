using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wish.Application.Requests.Auth;
using Wish.Application.Responses.Auth;
using Wish.Application.Responses.User;
using Wish.Application.Services;
using Wish.Domain.Entities;

namespace Wish.Web.Controllers
{
	[ApiController]
	[Route("api/user")]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
            _userService = userService;
		}

		[HttpGet]
		public async Task<Result<UserProfileResponse>> GetUserInfo(CancellationToken cancellationToken)
		{
			var result = await _userService.GetUserInfoAsync(cancellationToken);

			return result;
		}
	}
}
