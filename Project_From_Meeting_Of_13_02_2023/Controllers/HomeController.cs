using Microsoft.AspNetCore.Mvc;
using Project_From_Meeting_Of_13_02_2023.Models;
using System.Diagnostics;

namespace Project_From_Meeting_Of_13_02_2023.Controllers
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
			string controller = RouteData.Values["controller"]!.ToString()!;
			string action = RouteData.Values["action"]!.ToString()!;
			int? id = Convert.ToInt32(RouteData.Values["id"]?.ToString());
			return Content($"Controller: {controller} | Action: {action}, Id: {id}");
		}

		public IActionResult Privacy()
		{
			string? controller = RouteData.Values["controller"]!.ToString();
			string? action = RouteData.Values["action"]!.ToString();
			int? id = Convert.ToInt32(RouteData.Values["id"]?.ToString());
			return Content($"Controller: {controller} | Action: {action}, Id: {id}");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}