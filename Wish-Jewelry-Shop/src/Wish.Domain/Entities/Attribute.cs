using System.ComponentModel.DataAnnotations.Schema;
using Wish.Domain.Abstractions;
using Wish.Domain.Attributes;
using Wish.Domain.Constants;

namespace Wish.Domain.Entities
{
	[Table(Tables.Attributes)]
	public class Attribute : BaseEntity
	{
		[Column(Columns.ProductId)]
		public long ProductId { get; set; }

		[Column(Columns.Title)]
		public string Title { get; set; }
		[Column(Columns.Value)]
		public string Value { get; set; }
	}
}
