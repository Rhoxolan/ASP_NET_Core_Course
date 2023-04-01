using OnlineShop.Data;
using System.ComponentModel.DataAnnotations;
using static System.String;

namespace OnlineShop.Models.DTO.CategoryDTOs
{
	public class CategoryDTO
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Title")]
		public string Title { get; set; } = Empty;

		[Required]
		[Display(Name = "Parent Category")]
		public Category? ParentCategory { get; set; } = default;
	}
}
