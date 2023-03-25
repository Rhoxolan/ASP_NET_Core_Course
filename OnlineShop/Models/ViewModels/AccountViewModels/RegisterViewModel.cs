using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.ViewModels.AccountViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "Login")]
		public string Login { get; set; } = default!;

		[Required]
		[Display(Name = "Email address")]
		[DataType(DataType.EmailAddress)]
		public string EMail { get; set; } = default!;

		[Required]
		[Display (Name = "Year Of Birth")]
		public int YearOfBirth { get; set; }

		[Required]
		[Display(Name = "Password")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = default!;

		[Required]
		[Display(Name = "Confirm password")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "The passwords must mutch")]
		public string ConfirmPassword { get; set; } = default!;
	}
}
