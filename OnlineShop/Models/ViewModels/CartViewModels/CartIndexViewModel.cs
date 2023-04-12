using OnlineShop.Models.Domain;

namespace OnlineShop.Models.ViewModels.CartViewModels
{
	public class CartIndexViewModel
	{
		public Cart Cart { get; set; } = default!;
		public string ReturnUrl { get; set; } = default!;
	}
}
