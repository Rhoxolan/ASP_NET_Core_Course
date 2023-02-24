using _2023._01._27_HW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2023._01._27_HW.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private List<Book> books;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			books = new(); //Поэксперементировать с сервисом!
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
			books.Add(cppProgrammingLangguage);
			books.Add(cppSoftwareDesign);
		}

		public IActionResult Index()
		{
			return View(books);
		}

		public IActionResult Details(uint id)
		{
			return View(books.Where(b => b.Id == id).FirstOrDefault());
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}