using OnlineShop.Data;
using System.ComponentModel.DataAnnotations;
using static System.String;

namespace OnlineShop.Models.DTO.ProductDTOs
{
	public class ProductDTO
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Title")]
		public string Title { get; set; } = Empty;

		[Required]
		[Display(Name = "Price")]
		public double Price { get; set; }

		[Required]
		[Display(Name = "Count")]
		public int Count { get; set; }

		[Required]
		[Display(Name = "Category")]
		public Category Category { get; set; } = default!;
	}
}
