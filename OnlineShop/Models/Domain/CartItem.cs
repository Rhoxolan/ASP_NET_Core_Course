using OnlineShop.Data;

namespace OnlineShop.Models.Domain
{
    public class CartItem
    {
        public Product Product { get; set; } = default!;

        public int Count { get; set; } = default;
    }
}
