namespace _2023._01._27_PW3.Models
{
	public record Car()
	{
		public required string Model { get; set; }

		public required string Color { get; set; }

		public required string Mark { get; set; }

		public required int Year { get; set; }

		public required double EngineDisplacement { get; set; }
	}
}