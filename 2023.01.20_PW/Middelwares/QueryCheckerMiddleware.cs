namespace _2023._01._20_PW.Middelwares
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
            if (string.IsNullOrWhiteSpace(context.Request.Query["number"]))
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
