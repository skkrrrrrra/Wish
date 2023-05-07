using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wish.Domain.Constants;
using Wish.Domain.Entities;
using Attribute = Wish.Domain.Entities.Attribute;

namespace Wish.Application.Responses.Product
{
	public class ProductResponse
	{
		public long Id { get; set; }
		public string Title { get; set; }

		public string Description { get; set; }

		public long CategoryId { get; set; }

		public string PictureImage { get; set; }

		public double Weight { get; set; }

		public Material Material { get; set; }

		public long Count { get; set; }

		public decimal Price { get; set; }

		public virtual List<Attribute> Attributes { get; set; }
	}
}
