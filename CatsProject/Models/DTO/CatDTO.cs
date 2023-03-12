using BigProject.Data.Entities;
using CatsProject.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace BigProject.Models.DTO
{
	public class CatDTO
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Необхідно вказати  ім'я кота!")]
		[Display(Name = "Cat's name")]
		public string CatName { get; set; } = default!;

		public string? Description { get; set; }

		[Required]
		public CatGender Gender { get; set; }

		[Display(Name = "Status of Vactination")]
		public bool IsVacinated { get; set; }

		public byte[]? Image { get; set; }

		public BreedDTO? Breed { get; set; }

		public int BreedId { get; set; }
	}
}
