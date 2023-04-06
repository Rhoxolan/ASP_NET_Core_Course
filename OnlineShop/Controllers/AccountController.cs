using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models.DTO.UserDTOs;
using OnlineShop.Models.ViewModels.AccountViewModels;
using System.Security.Claims;
using static System.String;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
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
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(vm);
                var result = await _userManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
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

        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            LoginViewModel vm = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Login, vm.Password, vm.IsPersistent, false);
                if (result.Succeeded)
                {
                    if (!IsNullOrEmpty(vm.ReturnUrl) && Url.IsLocalUrl(vm.ReturnUrl))
                    {
                        return Redirect(vm.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Wrong login or password");
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult GoogleAuth()
        {
            string? redirectUrl = Url.Action(nameof(GoogleRedirect));
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            return Challenge(properties, "Google");
        }

        //Доп. пример с интернета - https://medium.com/c-sharp-progarmming/asp-net-core-google-authentication-4c0aa8feebbc
        public async Task<IActionResult> GoogleRedirect()
        {
            //Решить дупликате логинс

            ExternalLoginInfo? loginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (loginInfo is null)
            {
                return RedirectToAction(nameof(Login));
            }
            await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
            var userInfo = new Dictionary<string, string?>
            {
                ["Name"] = loginInfo.Principal.FindFirst(ClaimTypes.Name)?.Value + $"({loginInfo.Principal.FindFirst(ClaimTypes.Email)?.Value})", //Добавлено из-за необходимости соблюдения создания уникальных логинов. Альтернативный вариант, если необходимы не уникалньые логины - добавить пользователський валидатор.
                ["Email"] = loginInfo.Principal.FindFirst(ClaimTypes.Email)?.Value,
                ["LoginProvider"] = loginInfo.LoginProvider
            };
            User? user = await _userManager.Users
                .Where(u => u.Email == userInfo["Email"] && u.LoginProvider == "Google")
                .FirstOrDefaultAsync();
            if (user is not null)
            {
                await _signInManager.SignInAsync(user, true);
                return View(userInfo);
            }
            user = new User
            {
                UserName = userInfo["Name"],
                Email = userInfo["Email"],
                LoginProvider = userInfo["LoginProvider"]
            };
            var res = await _userManager.CreateAsync(user);
            await _userManager.AddLoginAsync(user, loginInfo);
            await _signInManager.SignInAsync(user, true);
            return View(userInfo);
        }

        //Old method from the lesson
        //public async Task<IActionResult> GoogleRedirectOld()
        //{
        //    ExternalLoginInfo? loginInfo = await _signInManager.GetExternalLoginInfoAsync();
        //    if (loginInfo is null)
        //    {
        //        return RedirectToAction(nameof(Login));
        //    }
        //    var loginResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
        //    string?[] userInfo =
        //    {
        //        loginInfo.Principal.FindFirst(ClaimTypes.Name)?.Value,
        //        loginInfo.Principal.FindFirst(ClaimTypes.Email)?.Value,
        //    };
        //    if (loginResult.Succeeded)
        //    {
        //        return View(userInfo);
        //    }
        //    User user = new User
        //    {
        //        UserName = userInfo[0],
        //        Email = userInfo[1]
        //    };
        //    var result = await _userManager.CreateAsync(user);
        //    if (result.Succeeded)
        //    {
        //        result = await _userManager.AddLoginAsync(user, loginInfo);
        //        if (result.Succeeded)
        //        {
        //            await _signInManager.SignInAsync(user, true);
        //            return View(userInfo);
        //        }
        //    }
        //    else
        //    {
        //        User? findedUser =
        //            await _userManager.FindByEmailAsync(userInfo[1]);
        //        if (findedUser is not null)
        //        {
        //            await _userManager.AddLoginAsync(findedUser!, loginInfo);
        //        }
        //    }
        //    return RedirectToAction(nameof(AccessDenied));
        //}

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
