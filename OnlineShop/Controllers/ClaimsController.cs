using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using System.Data;

namespace OnlineShop.Controllers
{
    //[Authorize(Roles = "Admin")]
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
            User user = await userManager.GetUserAsync(HttpContext.User);
            throw new NotImplementedException();
        }
    }
}
