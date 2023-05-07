using Wish.Application.Responses.Product;

namespace Wish.Application.Responses.CartshopItems
{
	public class OrderItem
	{
		public long Id { get; set; }
		public string Title { get; set; }

		public string PictureImage { get; set; }
		public long Count { get; set; }

		public decimal Price { get; set; }
	}
}
