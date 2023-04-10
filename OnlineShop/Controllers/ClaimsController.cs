using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using System.Data;
using System.Security.Claims;

namespace OnlineShop.Controllers
{
    //[Authorize(Policy = "ApplicationPolicy")]
    public class ClaimsController : Controller
    {
        private readonly UserManager<User> userManager;

        public ClaimsController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(User?.Claims);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string claimType, string claimValue)
        {
            User? user = await userManager.GetUserAsync(HttpContext.User);
            if (user is not null)
            {
                Claim claim = new(claimType, claimValue, ClaimValueTypes.String);
                var result = await userManager.AddClaimAsync(user, claim);
                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                Errors(result);
                return View();
            }
            return RedirectToAction("Login", "Account");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string claimsInfo)
        {
            User? user = await userManager.GetUserAsync(HttpContext.User);
            if (user is null)
            {
                return RedirectToAction(nameof(AccountController.Login), "Account");
            }
            string[] info = claimsInfo.Split(';');
            var claims = await userManager.GetClaimsAsync(user);
            Claim? claimForDelete = claims.FirstOrDefault(t => t.Type == info[0]
            && t.Value == info[1] && t.ValueType == info[2]);
            await userManager.RemoveClaimAsync(user, claimForDelete);
            return RedirectToAction(nameof(Index));
        }

        public void Errors(IdentityResult identityResult)
        {
            foreach(var error in identityResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
