using Microsoft.AspNetCore.Mvc;

namespace _2023._02._13_PW.Controllers
{
	public class ShopController : Controller
	{
		public IActionResult Buy() => Content("You're in the Buy Action!");
	}
}
