using Microsoft.EntityFrameworkCore;

namespace BigProject.Data.Entities
{
	public class CatContext : DbContext
	{
		public DbSet<Breed> Breeds { get; set; } = default!;

		public DbSet<Cat> Cats { get; set; } = default!;

		public CatContext(DbContextOptions<CatContext> options) : base(options)
		{

		}
	}
}
