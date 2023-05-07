using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wish.Domain.Constants;

namespace Wish.Domain.Abstractions;

public abstract class BaseEntity
{
	[Key]
	[Column(Columns.Id)]
	public long Id { get; set; }
}
