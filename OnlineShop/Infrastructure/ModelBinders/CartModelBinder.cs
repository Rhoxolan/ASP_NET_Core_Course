using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShop.Extensions;
using OnlineShop.Models.Domain;

namespace OnlineShop.Infrastructure.ModelBinders
{
    public class CartModelBinder : IModelBinder
    {
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            string sessionKey = "cart";
            Cart? cart = null;
            IEnumerable<CartItem>? cartItems = null; 
            if(bindingContext.HttpContext.Session != null)
            {
                cartItems
                    = bindingContext.HttpContext.Session.Get<IEnumerable<CartItem>>("cart");
            }
            throw new NotImplementedException();
        }
    }
}
