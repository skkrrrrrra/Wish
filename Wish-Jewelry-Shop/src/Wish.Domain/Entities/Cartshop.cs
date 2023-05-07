using System.ComponentModel.DataAnnotations.Schema;
using TeacherToys.Domain.Entities.Identity;
using Wish.Domain.Abstractions;
using Wish.Domain.Constants;

namespace Wish.Domain.Entities
{
	[Table(Tables.Cartshop)]
	public class Cartshop : BaseEntity
	{
		[Column(Columns.UserId)]
		[ForeignKey(nameof(User))]
		public long? UserId { get; set; }
		public virtual User User{ get; set; }

		[Column(Columns.ProductId)]
		[ForeignKey(nameof(Product))]
		public long ProductId { get; set; }
		public Product Product { get; set; }

		[Column(Columns.Count)]
		public long Count { get; set; }

		[Column(Columns.Price)]
		public decimal Price { get; set; }

		[Column(Columns.Status)]
		public long Status { get; set; }

		[Column(Columns.CreateDateTime)]
		public DateTime DateTime { get; set; } = DateTime.UtcNow;
	}
}
