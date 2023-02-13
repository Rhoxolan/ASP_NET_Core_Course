namespace _2023._01._20_PW.Middelwares
{
    public class QueryNumberCheckerMiddleware
    {
        private readonly RequestDelegate _next;

        public QueryNumberCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!ushort.TryParse(context.Request.Query["number"], out ushort number) || number > 25)
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
