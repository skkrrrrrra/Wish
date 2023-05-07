using System.ComponentModel.DataAnnotations.Schema;
using Wish.Domain.Abstractions;
using Wish.Domain.Attributes;
using Wish.Domain.Constants;
using static Wish.Domain.Enums.Types;

namespace Wish.Domain.Entities
{
	[Table(Tables.Products)]
	public class Product : BaseEntity
	{
		[Column(Columns.Title)]
		public string Title { get; set; }


		[Column(Columns.Description)]
		public string Description { get; set; }


		[Column(Columns.CategoryId)]
		public long CategoryId { get; set; }


		[Column(Columns.PictureImage)]
		public string PictureImage { get; set; }

		[Column(Columns.Material)]
		[ForeignKey(nameof(Material))]
		public long MaterialType { get; set; }
        public virtual Material Material { get; set; }


        [Column(Columns.Weight)]
		public double Weight { get; set; }


		[Column(Columns.Count)]
		public long Count { get; set; }


		[Column(Columns.Price)]
		public decimal Price { get; set; }

		public virtual List<Entities.Attribute> Attributes { get; set; }

	}
}
