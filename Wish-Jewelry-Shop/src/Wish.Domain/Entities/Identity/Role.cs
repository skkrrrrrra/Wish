using Microsoft.AspNetCore.Identity;
using TeacherToys.Domain.Entities.Identity;

namespace Wish.Domain.Entities.Identity;

public class Role : IdentityRole<long>
{
	public virtual ICollection<User> Users { get; set; }
}
