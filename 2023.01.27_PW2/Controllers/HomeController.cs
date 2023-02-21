using Microsoft.AspNetCore.Mvc;

namespace _2023._01._27_PW2.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
