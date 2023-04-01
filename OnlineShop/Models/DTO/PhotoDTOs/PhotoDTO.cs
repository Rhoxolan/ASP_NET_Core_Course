using OnlineShop.Data;
using System.ComponentModel.DataAnnotations;
using static System.String;

namespace OnlineShop.Models.DTO.PhotoDTOs
{
	public class PhotoDTO
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "File Name")]
		public string FileName { get; set; } = Empty;

		[Required]
		[Display(Name = "Photo Url")]
		public string PhotoUrl { get; set; } = Empty;

		[Required]
		[Display(Name = "Product")]
		public Product Product { get; set; } = default!;
	}
}
