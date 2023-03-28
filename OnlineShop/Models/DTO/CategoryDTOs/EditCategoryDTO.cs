using System.ComponentModel.DataAnnotations;
using static System.String;

namespace OnlineShop.Models.DTO.CategoryDTOs
{
	public class EditCategoryDTO
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Title")]
		public string Title { get; set; } = Empty;

		[Display(Name = "Parent Category Id")]
		public int? ParentCategoryId { get; set; }
	}
}
