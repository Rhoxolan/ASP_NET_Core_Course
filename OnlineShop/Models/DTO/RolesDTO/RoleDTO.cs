using System.ComponentModel.DataAnnotations;
using static System.String;

namespace OnlineShop.Models.DTO.RolesDTO
{
	public class RoleDTO
	{
		public string? Id { get; set; } = Empty;

		[Display(Name = "Role Name")]
		public string Name { get; set; } = Empty;
	}
}
