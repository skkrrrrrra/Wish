using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeacherToys.Domain.Entities.Identity;
using Wish.Domain.Abstractions;
using Wish.Domain.Attributes;
using Wish.Domain.Constants;
using Wish.Domain.Entities.Identity;

namespace Wish.Domain.Entities;

[Table(Tables.UserProfiles), Auditable]
public class UserProfile : BaseEntity
{
	[Key]
	[Column(Columns.Id)]
	[ForeignKey(nameof(User))]
	public new long Id { get; set; }
	public virtual User User { get; set; }

	[Column(Columns.Username)]
	public string Username { get; set; }

	[Column(Columns.FullName)]
	public string FullName { get; set;}

}
