namespace OnlineShop.Data
{
	public class Product
	{
		public int Id { get; set; }

		public string Title { get; set; } = default!;

		public double Price { get; set; }

		public int Count { get; set; }
	}
}
