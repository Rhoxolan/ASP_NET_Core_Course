using Microsoft.AspNetCore.Mvc;

namespace _2023._02._13_PW.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Test() => Content("You're in the Test action!");

		public IActionResult Reachable() => Content("You're in the Reachable action!");

		public IActionResult Settings(int id) => Content($"Your inputted id is {id}");
	}
}
