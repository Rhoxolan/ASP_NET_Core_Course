using BigProject.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CatsProject.Models.ViewModels.CatViewModels
{
	public class IndexCatViewModel
	{
		public IEnumerable<Cat> Cats { get; set; } = default!;

		public SelectList BreedSl { get; set; } = default!;

		public int BreedId { get; set; }

		public string? Search { get; set; }
	}
}
