using _2023._01._20_PW2.DrinkService;

namespace _2023._01._20_PW2.Middelwares
{
    public class DrinkMiddelware
    {
        public DrinkMiddelware(RequestDelegate _)
        {
        }

        public async Task InvokeAsync(HttpContext context, DrinkService.DrinkService drinkService)
        {
            IDrink? drink = default;
            switch (context.Request.Query["drink"])
            {
                case "tea":
                    drink = drinkService.GetTea();
                    break;
                case "coffe":
                    drink = drinkService.GetCoffe();
                    break;
                case "mineralwater":
                    drink = drinkService.GetMineralWater();
                    break;
            }
            await context.Response.WriteAsync($"The drink {drink!.Name.ToLower()} has {drink!.Calories} calories");
        }
    }
}
