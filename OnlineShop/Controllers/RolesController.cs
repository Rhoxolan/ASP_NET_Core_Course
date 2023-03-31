using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.Controllers
{
	public class RolesController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly RoleManager<IdentityRole> roleManager;

		public RolesController(UserManager<User> userManager,
			RoleManager<IdentityRole> roleManager)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
		}

		public async Task<IActionResult> Index()
		{
			return View(await roleManager.Roles.ToListAsync());
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				IdentityRole newRole = new(name);
				IdentityResult result = await roleManager.CreateAsync(newRole);
				if (result.Succeeded)
				{
					return RedirectToAction(nameof(Index));
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError(string.Empty, error.Description);
					}
				}
			}
			else
			{

				ModelState.AddModelError(string.Empty, "Role name isnt valid");
			}
			return View();
		}
	}
}
