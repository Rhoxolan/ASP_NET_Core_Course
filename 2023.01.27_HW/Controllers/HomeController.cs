using _2023._01._27_HW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2023._01._27_HW.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			Book cppProgrammingLangguage = new Book
			{
				Author = "Bjarne Stroustrup",
				Title = "The C++ Programming Language",
				Style = "technical literature",
				Publisher = "Addison–Wesley",
				Year = 2013,
				ImagePath = "Images/The_C++_Programming_Language,_Fourth_Edition.jpg"
			};
			Book cppSoftwareDesign = new Book
			{
				Author = "Klaus Iglberger",
				Title = "C++ Software Design",
				Style = "technical literature",
				Publisher = "O'Reilly Media, Inc.",
				Year = 2022,
				ImagePath = "/Images/cppsoftwaredesign.jfif"
            };
			List<Book> books = new List<Book>()
			{
				cppProgrammingLangguage,
				cppSoftwareDesign
			};
			return View(books);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}