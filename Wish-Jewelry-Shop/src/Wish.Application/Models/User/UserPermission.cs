namespace Wish.Application.Models.User;

public class UserPermission
{
	public IdNamePair Action { get; set; }
	public IdNamePair Subject { get; set; }
}
