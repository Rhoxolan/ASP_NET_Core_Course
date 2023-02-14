namespace _2023._01._20_PW2.Middelwares
{
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
}
