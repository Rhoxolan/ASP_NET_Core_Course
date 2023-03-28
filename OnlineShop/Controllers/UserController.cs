using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTO.UserDTOs;

namespace OnlineShop.Controllers
{
    //[Authorize(Roles = "admin")]
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

        public async Task<IActionResult> Create()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = userDTO.Email,
                    UserName = userDTO.Login,
                    YearOfBirth = userDTO.YearOfBirth,
                };
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userDTO);
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            //AutoMapper
            EditUserDTO dto = new EditUserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.UserName,
                YearOfBirth = user.YearOfBirth
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userDTO.Id);
                if (user == null)
                {
                    return NotFound();
                }
                user.UserName = userDTO.Login;
                user.Email = userDTO.Email;
                user.YearOfBirth = userDTO.YearOfBirth;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(userDTO);
        }

        public async Task<IActionResult> ChangePassword(string? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ChangePasswordDTO dto = new ChangePasswordDTO
            {
                Id = user.Id,
                Email = user.Email,
            };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dto)
        {
            var passwordValidator = HttpContext.RequestServices.GetRequiredService<IPasswordValidator<User>>();
            var passwordHasher = HttpContext.RequestServices.GetRequiredService<IPasswordHasher<User>>();
            throw new NotImplementedException();
        }
    }
}
