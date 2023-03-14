using Microsoft.AspNetCore.Mvc;

namespace Project_From_Meeting_Of_13_02_2023.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			string controller = RouteData.Values["controller"]!.ToString()!;
			string action = RouteData.Values["action"]!.ToString()!;
			int? id = Convert.ToInt32(RouteData.Values["id"]?.ToString());
			return Content($"Controller: {controller} | Action: {action}, Id: {id}");
		}

		public IActionResult Edit()
		{
			string controller = RouteData.Values["controller"]!.ToString()!;
			string action = RouteData.Values["action"]!.ToString()!;
			int? id = Convert.ToInt32(RouteData.Values["id"]?.ToString());
			return Content($"Controller: {controller} | Action: {action}, Id: {id}");
		}
	}
}
