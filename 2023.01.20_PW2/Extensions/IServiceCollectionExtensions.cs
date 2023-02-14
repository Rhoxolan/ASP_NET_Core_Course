using _2023._01._20_PW2.DrinkService;

namespace _2023._01._20_PW2.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddDrinkService(this IServiceCollection services)
        {
            services.AddTransient<IDrink, Tea>();
            services.AddTransient<IDrink, Coffe>();
            services.AddTransient<IDrink, MineralWater>();
            services.AddTransient<DrinkService.DrinkService>();
        }
    }
}
