using Microsoft.AspNetCore.Identity;
using TeacherToys.Domain.Entities.Identity;

namespace Wish.Domain.Entities.Identity;

public class UserRole : IdentityUserRole<long>
{
	public virtual User User { get; set; }
	public virtual Role Role { get; set; }
}
