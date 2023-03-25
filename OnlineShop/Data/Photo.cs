namespace OnlineShop.Data
{
	public class Photo
	{
		public int Id { get; set; }

		public string FileName { get; set; } = default!;

		public string PhotoUrl { get; set; } = default!;

		public int ProductId { get; set; }

		public Product Product { get; set; } = default!;
	}
}
