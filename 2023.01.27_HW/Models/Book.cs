namespace _2023._01._27_HW.Models
{
	public class Book
	{
		public required string Title { get; set; }

		public required string Author { get; set; }

		public required string Style { get; set; }

		public required string Publisher { get; set; }

		public required int Year { get; set; }

		public string? ImagePath { get; set; }
	}
}
