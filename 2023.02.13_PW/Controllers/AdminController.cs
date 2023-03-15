using Microsoft.AspNetCore.Mvc;

namespace _2023._02._13_PW.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
