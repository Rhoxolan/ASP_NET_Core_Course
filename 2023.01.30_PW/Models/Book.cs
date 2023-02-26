namespace _2023._01._30_PW.Models
{
	public class Book
	{
		public required uint Id { get; set; }

		public required string Title { get; set; }

		public required string Author { get; set; }

		public required string Style { get; set; }

		public required string Publisher { get; set; }

		public required int Year { get; set; }

		public string? ImagePath { get; set; }

		public required string Description { get; set; }
	}
}
