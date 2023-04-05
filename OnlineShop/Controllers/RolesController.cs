using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTO.RoleDTOs;
using OnlineShop.Models.DTO.UserDTOs;
using OnlineShop.Models.ViewModels.RolesViewModels;
using System.Data;

namespace OnlineShop.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RolesController : Controller
	{
		private readonly UserManager<User> userManager;
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly IMapper _mapper;

		public RolesController(UserManager<User> userManager,
			RoleManager<IdentityRole> roleManager,
			IMapper mapper)
		{
			this.userManager = userManager;
			this.roleManager = roleManager;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			return View(await roleManager.Roles.Select(r => _mapper.Map<RoleDTO>(r)).ToListAsync());
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

		public async Task<IActionResult> Delete(string? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}
			IdentityRole role = await roleManager.FindByIdAsync(id);
			if (role is null)
			{
				return NotFound();
			}
			return View(_mapper.Map<RoleDTO>(role));
		}


		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}
			IdentityRole role = await roleManager.FindByIdAsync(id);
			if (role is not null)
			{
				await roleManager.DeleteAsync(role);
			}
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> UserList()
		{
			return View(await userManager.Users.Select(u => _mapper.Map<UserDTO>(u)).ToListAsync());
		}

		public async Task<IActionResult> ChangeUserRoles(string? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}
			User user = await userManager.FindByIdAsync(id);
			if (user is null)
			{
				return NotFound();
			}
			var userRoles = await userManager.GetRolesAsync(user);
			var allRoles = await roleManager.Roles.ToListAsync();
			ChangeRoleViewModel vm = _mapper.Map<ChangeRoleViewModel>(user);
			vm.UserRoles = userRoles;
			vm.AllRoles = allRoles;
			return View(vm);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ChangeUserRoles(string? id, List<string> roles)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}
			User? user = await userManager.FindByIdAsync(id);
			if (user is null)
			{
				return NotFound();
			}
			var userRoles = await userManager.GetRolesAsync(user);
			var addedRoles = roles.Except(userRoles);
			var deletedRoles = userRoles.Except(roles);
			await userManager.AddToRolesAsync(user, addedRoles);
			await userManager.RemoveFromRolesAsync(user, deletedRoles);
			return RedirectToAction(nameof(UserList));
		}
	}
}
