using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShop.Extensions;
using OnlineShop.Models.Domain;

namespace OnlineShop.Infrastructure.ModelBinders
{
    public class CartModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            string sessionKey = "cart";
            IEnumerable<CartItem>? cartItems = null; 
            if(bindingContext.HttpContext.Session != null)
            {
                cartItems
                    = bindingContext.HttpContext.Session.Get<IEnumerable<CartItem>>(sessionKey);
            }
            if(cartItems == null)
            {
                cartItems = new List<CartItem>();
                bindingContext.HttpContext.Session!.Set(sessionKey, cartItems);
            }
            Cart cart = new(cartItems);
            bindingContext.Result = ModelBindingResult.Success(cart);
            return Task.CompletedTask;
        }
    }
}
