using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Models.ViewModels.RolesViewModels
{
	public class ChangeRoleViewModel
	{
		public string UserId { get; set; } = default!;

		public string UserName { get; set; } = default!;

		public IList<string> UserRoles { get; set; } = default!;

		public IList<IdentityRole> AllRoles { get; set; } = default!;
	}
}
