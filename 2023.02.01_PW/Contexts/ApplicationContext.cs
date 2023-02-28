using _2023._02._01_PW.Models;
using Microsoft.EntityFrameworkCore;

namespace _2023._02._01_PW.Contexts
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
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
				ImagePath = "/images/The_C++_Programming_Language,_Fourth_Edition.jpg",
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
				ImagePath = "/images/cppsoftwaredesign.jfif",
				Description = "The book about software design and pattenrns on the C++ programming language"
			};
			modelBuilder.Entity<Book>().HasData(cppProgrammingLangguage, cppSoftwareDesign);
		}
	}
}
