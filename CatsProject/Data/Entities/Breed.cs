using System.ComponentModel.DataAnnotations;

namespace BigProject.Data.Entities
{
	public class Breed
	{
		public int Id { get; set; }

		public string BreedName { get; set; } = default!;

		public ICollection<Cat> Cats { get; set; } = default!;
	}
}
