using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
