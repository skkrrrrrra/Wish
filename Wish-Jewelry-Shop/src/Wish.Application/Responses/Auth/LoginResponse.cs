using Wish.Application.Models.User;

namespace Wish.Application.Responses.Auth;

public sealed class LoginResponse
{
	public string Token { get; set; } = string.Empty;
	public UserData UserData { get; set; }
}
