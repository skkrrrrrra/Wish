using System.ComponentModel.DataAnnotations.Schema;
using Wish.Domain.Constants;
using Wish.Domain.Entities.Identity;

namespace Wish.Domain.Abstractions;

public abstract class AuditableEntity : BaseEntity
{
	[Column(Columns.Deleted)]
	public bool IsDeleted { get; set; }
}
