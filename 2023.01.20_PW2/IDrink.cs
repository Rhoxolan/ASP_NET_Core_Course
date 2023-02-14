namespace _2023._01._20_PW2
{
    public interface IDrink
    {
        public string Name { get; }

        public double Calories { get; }
    }

    public class Tea : IDrink
    {
        public string Name
            => "Tea";

        public double Calories
            => 1;
    }

    public class Coffe : IDrink
    {
        public string Name
            => "Coffe";

        public double Calories
            => 0.5;
    }

    public class MineralWater : IDrink
    {
        public MineralWater()
        {
        }

        public string Name
            => "Mineral water";

        public double Calories
            => 0;
    }

    public class DrinkService
    {
        private IEnumerable<IDrink> _drinks;

        public DrinkService(IEnumerable<IDrink> drinks)
        {
            _drinks = drinks;
        }

        public IDrink? GetTea()
        {
            return _drinks.Where(d => d is Tea).FirstOrDefault();
        }

        public IDrink? GetCoffe()
        {
            return _drinks.Where(d => d is Coffe).FirstOrDefault();
        }

        public IDrink? GetMineralWater()
        {
            return _drinks.Where(d => d is MineralWater).FirstOrDefault();
        }
    }

    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == 405)
            {
                await context.Response.WriteAsync("Bad request");
            }
        }
    }

    public class QueryCheckerMiddleware
    {
        private readonly RequestDelegate _next;

        public QueryCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Request.Query["drink"]))
            {
                context.Response.StatusCode = 405;
            }
            else
            {
                await _next(context);
            }
        }
    }

    public class QueryDrinkCheckerMiddleware
    {
        private readonly RequestDelegate _next;

        public QueryDrinkCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string drinkQuery = context.Request.Query["drink"]!;
            if (drinkQuery == "tea" || drinkQuery == "coffe" || drinkQuery == "mineralwater")
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 405;
            }
        }
    }

    public class DrinkMiddelware
    {
        public DrinkMiddelware(RequestDelegate _)
        {
        }

        public async Task InvokeAsync(HttpContext context, DrinkService drinkService)
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
            await context.Response.WriteAsync($"The drink {drink!.Name} has {drink!.Calories} calories");
        }
    }
}
