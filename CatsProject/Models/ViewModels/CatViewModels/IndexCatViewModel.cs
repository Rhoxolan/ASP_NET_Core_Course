using BigProject.Data.Entities;
using BigProject.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatsProject.Models.ViewModels.CatViewModels
{
	public class IndexCatViewModel
	{
		public IEnumerable<CatDTO> Cats { get; set; } = default!;

		public SelectList BreedSl { get; set; } = default!;

		public int BreedId { get; set; }

		public string? Search { get; set; }
	}
}
