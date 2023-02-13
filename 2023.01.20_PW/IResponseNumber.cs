using static System.Convert;

namespace _2023._01._20_PW
{
    public interface IResponseNumber
    {
        public ulong ResponseNumber(ushort requestNumber);
    }

    public class FibonacciResponse : IResponseNumber
    {
        public ulong ResponseNumber(ushort requestNumber)
        {
            if (requestNumber == 0 || requestNumber == 1)
            {
                return requestNumber;
            }
            List<ulong> fl = new() { 0, 1 };
            for (ushort i = 0; i < (requestNumber - 1); i++)
            {
                fl.Add(fl[^1] + fl[^2]);
            }
            return fl[^1];
        }
    }

    public class FactorialResponse : IResponseNumber
    {
        public ulong ResponseNumber(ushort requestNumber)
        {
            if (requestNumber == 0 || requestNumber == 1)
            {
                return 1;
            }
            ulong factorial = 1;
            for (ulong i = 1; i <= requestNumber; i++)
            {
                factorial *= i;
            }
            return factorial;
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

    public class ResponseNumberMiddleware
    {
        public ResponseNumberMiddleware(RequestDelegate _)
        {
        }

        public async Task InvokeAsync(HttpContext context, IResponseNumber responseNumber)
            => await context.Response.WriteAsync($"{responseNumber.ResponseNumber(ToUInt16(context.Request.Query["number"]))}");
    }
}
