using System.ComponentModel.DataAnnotations;

namespace CatsProject.Models.DTO
{
    public enum CatGender
    {
        [Display(Name = "Boy")]
        Male,
        [Display(Name = "Girl")]
        Female
    }
}
