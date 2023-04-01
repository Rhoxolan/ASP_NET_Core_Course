using System.ComponentModel.DataAnnotations;
using static System.String;

namespace OnlineShop.Models.DTO.PhotoDTOs
{
	public class EditPhotoDTO
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "File Name")]
		public string FileName { get; set; } = Empty;

		[Required]
		[Display(Name = "Photo Url")]
		public string PhotoUrl { get; set; } = Empty;

		[Required]
		[Display(Name = "Product Id")]
		public int ProductId { get; set; }
	}
}
