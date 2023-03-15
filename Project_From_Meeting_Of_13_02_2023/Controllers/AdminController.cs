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

		public IActionResult Delete(int? id)
		{
			string? controller = RouteData.Values["controller"]!.ToString();
			string? action = RouteData.Values["action"]!.ToString();
			int? routeId = Convert.ToInt32(RouteData.Values["id"]?.ToString());
			string? queryId = Request.Query["id"];
			string? formId = string.Empty;
			//if (Request.Form.Count != 0 && Request.Form.ContainsKey("id"))
			//{
			//	formId = HttpContext.Request.Form["id"];
			//}
			return Content($"Controller: {controller} | Action: {action}, Id: {id}, Id From Query: {queryId}, " +
				$"Id from Form: {formId}, Id from Route: {routeId}");
		}

		public IActionResult Show(string name, int age)
		{
			string? controller = RouteData.Values["controller"]!.ToString();
			string? action = RouteData.Values["action"]!.ToString();
			return Content($"Controller: {controller} | Action: {action}, Name: {name}, " +
				$"{age} years old");
		}

		public IActionResult Show(string name, string position)
		{
			string? controller = RouteData.Values["controller"]!.ToString();
			string? action = RouteData.Values["action"]!.ToString();
			return Content($"Controller: {controller} | Action: {action}, Name: {name}, " +
				$"Position: {position}");
		}
	}
}
