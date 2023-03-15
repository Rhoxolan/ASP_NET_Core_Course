using Microsoft.AspNetCore.Mvc;

namespace _2023._02._13_PW.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult InSetup() => Content("You're in the Setup action!");

		public IActionResult InWorking() => Content("You're in the Working action!");
	}
}
