namespace _2023._01._18_PW
{
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
            List<ulong> fl = new() { 0, 1 };
            for (int i = 0; i < (num - 1); i++)
            {
                fl.Add(fl[^1] + fl[^2]);
            }
            await context.Response.WriteAsync(fl[^1].ToString());
        }
    }
}
