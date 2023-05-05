using Microsoft.EntityFrameworkCore;
using GarageProject.Models;

namespace GarageProject.Data
{
	public class CarsDBContext : DbContext
	{
		public DbSet<Car> Cars { get; set; } = default!;

		public CarsDBContext(DbContextOptions<CarsDBContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			Car car1 = new Car
			{
				Id = 1,
				Manufacturer = "Mercedes",
				Model = "CLS",
				Price = 80000,
				Year = 2020
			};
			Car car2 = new Car
			{
				Id = 2,
				Manufacturer = "VW",
				Model = "Jetta",
				Price = 20000,
				Year = 2016
			};
			Car car3 = new Car
			{
				Id = 3,
				Manufacturer = "Audi",
				Model = "R8",
				Price = 300000,
				Year = 2021
			};
			modelBuilder.Entity<Car>().HasData(
				car1, car2, car3);
		}
	}
}
