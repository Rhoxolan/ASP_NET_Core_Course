using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.Data
{
	public class Product
	{
		public int Id { get; set; }

		public string Title { get; set; } = default!;

		public double Price { get; set; }

		public int Count { get; set; }

		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }

		public Category Category { get; set; } = default!;

        public List<Product>? Products { get; set; } = default!;
	}
}
