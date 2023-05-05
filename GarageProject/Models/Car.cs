namespace GarageProject.Models
{
	public class Car
	{
		public int Id { get; set; }

		public string Model { get; set; } = default!;

		public string Manufacturer { get; set; } = default!;

		public double Price { get; set; }

		public int Year { get; set; }
	}
}
