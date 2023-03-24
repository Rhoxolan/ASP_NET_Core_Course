namespace OnlineShop.Data
{
	public class Category
	{
		public int Id { get; set; }

		public string Title { get; set; } = default!;

		public int? ParentCategoryId { get; set; }

		public Category? ParentCategory { get; set; } = default!;
	}
}
