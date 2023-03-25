using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models.ViewModels.AccountViewModels;

namespace OnlineShop.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public AccountController(UserManager<User> userManager,
			SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task <IActionResult> Register(RegisterViewModel vm)
		{
			if (ModelState.IsValid)
			{
				User user = new User
				{
					Email = vm.EMail,
					UserName = vm.Login,
					YearOfBirth = vm.YearOfBirth,
				};
				var result = await _userManager.CreateAsync(user, vm.Password);
				if(result.Succeeded)
				{
					await _signInManager.SignInAsync(user, true);
					return RedirectToAction("Index", "Home");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View(vm);
		}
	}
}
