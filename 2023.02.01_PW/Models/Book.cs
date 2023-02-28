namespace _2023._02._01_PW.Models
{
	public class Book
	{
		public required int Id { get; set; }

		public required string Title { get; set; }

		public required string Author { get; set; }

		public required string Style { get; set; }

		public required string Publisher { get; set; }

		public required int Year { get; set; }

		public string? ImagePath { get; set; }

		public required string Description { get; set; }
	}
}
