using OnlineShop.Data;

namespace OnlineShop.Models.Domain
{
    public class Cart
    {
        List<CartItem> cartItems = new();

        public IEnumerable<CartItem> CartItems
        {
            get
            {
                return cartItems;
            }
        }

        public void AddToCart(Product product, int count)
        {
            CartItem? item = cartItems.FirstOrDefault(t => t.Product.Id == product.Id);
            if(item is not null)
            {
                
            }
        }
    }
}
