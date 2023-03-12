using System.ComponentModel.DataAnnotations;

namespace BigProject.Data.Entities
{
	public class Cat
	{
		public int Id { get; set; }

		public string CatName { get; set; } = default!;

		public string? Description { get; set; }

		public CatGender Gender { get; set; }

		public bool IsVacinated { get; set; }

		public byte[]? Image { get; set; }

		public bool IsDeleted { get; set; }

		public Breed? Breed { get; set; }

		public int BreedId { get; set; }
	}

	public enum CatGender
	{
		Male,
		Female
	}
}
