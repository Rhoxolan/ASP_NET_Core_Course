using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;

namespace OnlineShop.ViewComponents
{
	[ViewComponent]
	public class CategoriesMenuViewComponent : ViewComponent
	{
		private readonly ShopDbContext _context;

		public CategoriesMenuViewComponent(ShopDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync(string? currentCategory)
		{
			List<string> categoryNames = await _context.Products.Include(c => c.Category)
				.Select(c => c.Category.Title)
				.Distinct()
				.ToListAsync();
			return View(new Tuple<List<string>, string?>(categoryNames, currentCategory));
		}
	}
}
