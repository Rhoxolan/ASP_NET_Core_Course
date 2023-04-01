using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OnlineShop.Models.DTO.UserDTOs
{
	public class UserDTO
	{
		[Required]
		public string Id { get; set; } = default!;

		[Required]
		[Display(Name = "Login")]
		public string Login { get; set; } = default!;

		[Required]
		[Display(Name = "Date of Birth")]
		public int YearOfBirth { get; set; }

		[Required]
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = default!;
	}
}
