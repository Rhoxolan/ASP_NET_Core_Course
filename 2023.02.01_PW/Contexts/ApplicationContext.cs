using _2023._02._01_PW.Models;
using Microsoft.EntityFrameworkCore;
using static System.IO.File;
using static System.IO.Path;

namespace _2023._02._01_PW.Contexts
{
	public class ApplicationContext : DbContext
	{
		private readonly IWebHostEnvironment _environment;

		public ApplicationContext(DbContextOptions<ApplicationContext> options, IWebHostEnvironment environment) : base(options)
		{
			_environment = environment;
			Database.EnsureCreated();
		}

		public DbSet<Book> Books { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			Book cppProgrammingLangguage = new Book
			{
				Id = 1,
				Author = "Bjarne Stroustrup",
				Title = "The C++ Programming Language",
				Style = "technical literature",
				Publisher = "Addison–Wesley",
				Year = 2013,
				Cover = ReadAllBytes(Combine(_environment.WebRootPath, "images", "The_C++_Programming_Language,_Fourth_Edition.jpg")), 
				Description = "The book about C++ programming language"
			};
			Book cppSoftwareDesign = new Book
			{
				Id = 2,
				Author = "Klaus Iglberger",
				Title = "C++ Software Design",
				Style = "technical literature",
				Publisher = "O'Reilly Media, Inc.",
				Year = 2022,
				Cover = ReadAllBytes(Combine(_environment.WebRootPath, "images", "cppsoftwaredesign.jfif")),
				Description = "The book about software design and pattenrns on the C++ programming language"
			};
			modelBuilder.Entity<Book>().HasData(cppProgrammingLangguage, cppSoftwareDesign);
		}
	}
}
