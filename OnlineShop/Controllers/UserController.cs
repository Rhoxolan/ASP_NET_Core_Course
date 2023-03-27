using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Controllers
{
	public class UserController : Controller
	{
		private readonly UserManager<User> _userManager;

		public UserController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _userManager.Users.ToListAsync());
		}
	}
}
