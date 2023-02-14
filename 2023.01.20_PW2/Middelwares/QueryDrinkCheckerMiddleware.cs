namespace _2023._01._20_PW2.Middelwares
{
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
}
