using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Extensions;
using OnlineShop.Models.Domain;
using OnlineShop.Models.ViewModels.CartViewModels;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopDbContext _context;

        public CartController(ShopDbContext context)
        {
            _context = context;
        }

		public IActionResult Index(string returnUrl)
		{
			Cart cart = GetCart();
            CartIndexViewModel viewModel = new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };
			return View(viewModel);
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> AddToCart(int id, string returnUrl)
        {
            Cart cart = GetCart();
            Product? product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                cart.AddToCart(product, 1);
                HttpContext.Session.Set("cart", cart.CartItems);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFromCart(int id, string returnUrl)
        {
            throw new NotImplementedException();
		}

        private Cart GetCart()
        {
            IEnumerable<CartItem>? cartItems = HttpContext.Session.Get<IEnumerable<CartItem>>("cart");
            Cart? cart = null;
            if (cartItems == null)
            {
                cart = new Cart();
            }
            else
            {
                cart = new Cart(cartItems!);
            }
            return cart;
        }
    }
}
