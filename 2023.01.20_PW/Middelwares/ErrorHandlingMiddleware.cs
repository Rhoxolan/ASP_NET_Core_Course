namespace _2023._01._20_PW.Middelwares
{
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
}
