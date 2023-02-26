using _2023._01._30_PW.Models;

namespace _2023._01._30_PW.Repositories
{
	public class BookRepository
	{
		public List<Book> Books { get; } = new();

		public BookRepository()
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
			Books.Add(cppProgrammingLangguage);
			Books.Add(cppSoftwareDesign);
		}
	}
}
