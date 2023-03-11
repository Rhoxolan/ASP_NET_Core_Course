using BigProject.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace BigProject.Models.DTO
{
    public class BreedDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Cat's breed")]
        public string BreedName { get; set; } = default!;

        public ICollection<CatDTO> Cats { get; set; } = default!;
    }
}
