using Microsoft.AspNetCore.Mvc.ModelBinding;
using OnlineShop.Infrastructure.ModelBinders;
using OnlineShop.Models.Domain;

namespace OnlineShop.Infrastructure.ModelBinderProviders
{
    public class CartModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
            => context.Metadata.ModelType == typeof(Cart)
                ? new CartModelBinder() : null;
    }
}
