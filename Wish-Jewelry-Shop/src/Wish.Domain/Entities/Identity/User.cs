using Microsoft.AspNetCore.Identity;
using Wish.Domain.Entities;
using Wish.Domain.Entities.Identity;

namespace TeacherToys.Domain.Entities.Identity;

public class User : IdentityUser<long>
{
	public virtual UserProfile UserProfile { get; set; }

	public virtual IEnumerable<Role> Roles { get; set; }
}
