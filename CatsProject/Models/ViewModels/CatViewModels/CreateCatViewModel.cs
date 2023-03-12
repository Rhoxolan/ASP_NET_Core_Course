using BigProject.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatsProject.Models.ViewModels.CatViewModels
{
	public class CreateCatViewModel
	{
		public CatDTO Cat { get; set; } = default!;

		public SelectList? BreedSL { get; set; } = default!;

        public IFormFile Image { get; set; } = default!;

		//public SelectList GetGenderSL { get; set; } = default!;
	}
}
