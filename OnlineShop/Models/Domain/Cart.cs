using OnlineShop.Data;

namespace OnlineShop.Models.Domain
{
    public class Cart
    {
        private List<CartItem> cartItems;

        public Cart()
        {
            cartItems = new();
        }
        public Cart(IEnumerable<CartItem> cartItems)
        {
            this.cartItems = cartItems.ToList();
        }

        public IEnumerable<CartItem> CartItems
            => cartItems;

        public void AddToCart(Product product, int count)
        {
            CartItem? item = cartItems.FirstOrDefault(t => t.Product.Id == product.Id);
            if(item is not null)
            {
                item.Count += count;
            }
            else
            {
                cartItems.Add(new CartItem { Product = product, Count = count });
            }
        }

        public void RemoveFromCart(Product product)
            => cartItems.RemoveAll(t => t.Product.Id == product.Id);

        public void Clear()
            => cartItems.Clear();

        public double TotalPrice
            => cartItems.Sum(t => t.Product.Price * t.Count);
    }
}
