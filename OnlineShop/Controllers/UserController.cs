using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTO.UserDTOs;

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
			var users = _userManager.Users;
			//Use AutoMapper in Future
			IEnumerable<UserDTO> usersDTO = await users.Select(t => new UserDTO
			{
				Id = t.Id,
				Login = t.UserName,
				Email = t.Email,
				YearOfBirth = t.YearOfBirth
			}).ToListAsync();
			return View(usersDTO);
		}
	}
}
