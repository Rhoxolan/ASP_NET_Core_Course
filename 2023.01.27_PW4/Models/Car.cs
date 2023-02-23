using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _2023._01._27_PW4.Models
{
	public record Car()
	{
		[BindRequired]
		public required string Model { get; set; }

		[BindRequired]
		public required string Color { get; set; }

		[BindRequired]
		public required string Mark { get; set; }

		[BindRequired]
		public required int Year { get; set; }

		[BindRequired]
		public required double EngineDisplacement { get; set; }
	}
}
