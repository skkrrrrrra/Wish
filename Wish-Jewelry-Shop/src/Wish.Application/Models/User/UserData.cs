
using Microsoft.AspNetCore.Identity;
using Wish.Domain.Entities.Identity;
namespace Wish.Application.Models.User;


public class UserData
{
	public long Id { get; set; }
	public string FullName { get; set; } = string.Empty;
	public string Role { get; set; } = string.Empty;
	public string UserName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
}
