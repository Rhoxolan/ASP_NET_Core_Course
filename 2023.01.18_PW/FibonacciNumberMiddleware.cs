namespace _2023._01._18_PW
{
    public class FirstFibonacciNumbersMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstFibonacciNumbersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ulong num)
        {
            List<ulong> fl = new()
            {
                0, 1
            };
            for (ulong i = 0; i < num; i++)
            {
                fl.Add(fl[^1] + fl[^2]);
            }
            await context.Response.WriteAsync(num.ToString());
        }
    }

    public class FibonacciNumberMiddleware
    {
        private readonly RequestDelegate _next;

        public FibonacciNumberMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ulong num)
        {
            List<ulong> fl = new()
            {
                0, 1
            };
            for (ulong i = 0; i < num; i++)
            {
                fl.Add(fl[^1] + fl[^2]);
            }
            await context.Response.WriteAsync(num.ToString());
        }
    }
}