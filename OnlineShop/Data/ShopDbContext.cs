using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models.DTO.UserDTOs;
using OnlineShop.Models.DTO.RoleDTOs;

namespace OnlineShop.Data
{
	public class ShopDbContext : IdentityDbContext<User>
	{
		public DbSet<Photo> Photos { get; set; } = default!;

		public DbSet<Category> Categories { get; set; } = default!;

		public DbSet<Product> Products { get; set; } = default!;

		public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<OnlineShop.Models.DTO.UserDTOs.UserDTO>? UserDTO { get; set; }

		public DbSet<OnlineShop.Models.DTO.RoleDTOs.RoleDTO>? RoleDTO { get; set; }
	}
}
