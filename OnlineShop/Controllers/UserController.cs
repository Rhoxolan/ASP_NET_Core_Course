using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTO.UserDTOs;

namespace OnlineShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userManager.Users.Select(u => _mapper.Map<UserDTO>(u)).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(userDTO);
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
            return View(_mapper.Map<EditUserDTO>(user));
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
            return View(_mapper.Map<ChangePasswordDTO>(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO dto)
        {
            //Можно использовать метод ChangePasswordAsync()
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(dto.Id);
                var passwordValidator = HttpContext.RequestServices.GetRequiredService<IPasswordValidator<User>>();
                var passwordHasher = HttpContext.RequestServices.GetRequiredService<IPasswordHasher<User>>();
                if(user is null)
                {
                    return NotFound();
                }
                var identityResult = await passwordValidator.ValidateAsync(_userManager, user, dto.NewPassword);
                if(identityResult.Succeeded)
                {
                    var hashedPassword = passwordHasher.HashPassword(user, dto.NewPassword);
                    user.PasswordHash = hashedPassword;
                    await _userManager.UpdateAsync(user);
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var error in identityResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(dto);
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<UserDTO>(user));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
