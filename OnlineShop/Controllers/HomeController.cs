using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Models.ViewModels.HomeViewModels;
using System.Diagnostics;
using static System.String;

namespace OnlineShop.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly ShopDbContext _context;

        public HomeController(ILogger<HomeController> logger, ShopDbContext context)
		{
			_logger = logger;
            _context = context;
        }

		public async Task<IActionResult> Index(string? category)
		{
			IQueryable<Product> products = _context.Products
				.Include(p => p.Category)
				.Include(p => p.Photos);
			if (!IsNullOrEmpty(category))
			{
				products = products.Where(p => p.Category.Title == category);
			}
			HomeIndexViewModel vm = new HomeIndexViewModel
			{
				Products = await products.ToListAsync(),
				Category = category
			};
			return View(vm);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}