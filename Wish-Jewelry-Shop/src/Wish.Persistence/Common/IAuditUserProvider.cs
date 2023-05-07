namespace Wish.Persistence.Common;

public interface IAuditUserProvider
{
	long? GetUserId();
	string GetUserRole();
}
