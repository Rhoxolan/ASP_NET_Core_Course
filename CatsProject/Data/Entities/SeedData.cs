using Microsoft.EntityFrameworkCore;

namespace BigProject.Data.Entities
{
	public static class SeedData
	{
		public static async Task Initialize(IServiceProvider serviceProvider,
			IWebHostEnvironment hostEnvironment)
		{
			DbContextOptions<CatContext> options
				= serviceProvider.GetRequiredService<DbContextOptions<CatContext>>();
			using (CatContext context = new CatContext(options))
			{
				context.Database.EnsureCreated();
				if (context.Cats.Any())
				{
					return;
				}
				string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse mauris velit, elementum in viverra ac, " +
					"vulputate sed ex. Vestibulum rutrum imperdiet risus at porttitor. Nullam tortor eros, sagittis in viverra a, pellentesque at sapien. " +
					"Mauris magna est, tempus at cursus eget, venenatis id mi. Mauris sit amet dui odio. Pellentesque euismod venenatis dui sit amet " +
					"interdum. Aliquam finibus, lorem vitae efficitur pellentesque, lacus odio tincidunt arcu, sit amet vehicula nunc tellus in arcu. " +
					"Quisque tellus leo, mattis eu nunc sit.";
				byte[] catimage1 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\cat1.jpg");
				byte[] catimage2 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\cat2.jpg");
				byte[] catimage3 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\cat3.jpg");
				byte[] catimage4 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\cat4.jpg");
				byte[] catimage5 = File.ReadAllBytes($"{hostEnvironment.WebRootPath}\\images\\cat5.jpg");
				Breed breed1 = new Breed { BreedName = "Siam Oriental" };
				Breed breed2 = new Breed { BreedName = "Bengal" };
				Breed breed3 = new Breed { BreedName = "Siam" };
				Breed breed4 = new Breed { BreedName = "Ukrainian" };
				await context.Breeds.AddRangeAsync(breed1, breed2, breed3, breed4);
				Cat cat1 = new Cat
				{
					CatName = "Moorka",
					Description = lorem,
					Gender = CatGender.Female,
					IsVacinated = true,
					Image = catimage1,
					Breed = breed1,
					IsDeleted = false
				};
				Cat cat2 = new Cat
				{
					CatName = "Vasyl",
					Description = lorem,
					Gender = CatGender.Male,
					IsVacinated = false,
					Image = catimage2,
					Breed = breed4,
					IsDeleted = false
				};
				Cat cat3 = new Cat
				{
					CatName = "Barsyk",
					Description = lorem,
					Gender = CatGender.Male,
					IsVacinated = true,
					Image = catimage3,
					Breed = breed2,
					IsDeleted = false
				};
				Cat cat4 = new Cat
				{
					CatName = "Lucy",
					Description = lorem,
					Gender = CatGender.Female,
					IsVacinated = true,
					Image = catimage4,
					Breed = breed3,
					IsDeleted = false
				};
				Cat cat5 = new Cat
				{
					CatName = "Umka",
					Description = lorem,
					Gender = CatGender.Female,
					IsVacinated = false,
					Image = catimage5,
					Breed = breed4,
					IsDeleted = true
				};
				await context.Cats.AddRangeAsync(cat1, cat2, cat3, cat4, cat5);
				await context.SaveChangesAsync();
			}
		}
	}
}
