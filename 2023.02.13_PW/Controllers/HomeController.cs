using _2023._02._13_PW.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _2023._02._13_PW.Controllers
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
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Test() => Content("You're in the test action!");

		public IActionResult Unreachable() => Content("You're in the Unreachable action!");

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}