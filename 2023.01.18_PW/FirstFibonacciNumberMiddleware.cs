namespace _2023._01._18_PW
{
    public class FirstFibonacciNumberMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstFibonacciNumberMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //Разнести на несколько классов
        public async Task InvokeAsync(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Request.Query["number"]))
            {
                context.Response.StatusCode = 405;
            }
            else
            {
                if (!ushort.TryParse(context.Request.Query["number"], out ushort num))
                {
                    context.Response.StatusCode = 405;
                }
                else
                {
                    if (num == 0 || num == 1)
                    {
                        await context.Response.WriteAsync(num.ToString());
                    }
                    else
                    {
                        await _next(context);
                    }
                }
            }
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

    public class FibonacciMiddleware
    {
        private readonly RequestDelegate _next;

        public FibonacciMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ushort num = Convert.ToUInt16(context.Request.Query["number"]);
            List<UInt128> fl = new() { 0, 1 };
            for (int i = 0; i < (num - 1); i++)
            {
                fl.Add(fl[^1] + fl[^2]);
            }
            await context.Response.WriteAsync(fl[^1].ToString());
        }
    }
}
