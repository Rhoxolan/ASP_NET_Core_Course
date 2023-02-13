using _2023._01._20_PW.ResponseNumber;
using static System.Convert;

namespace _2023._01._20_PW.Middelwares
{
    public class ResponseNumberMiddleware
    {
        public ResponseNumberMiddleware(RequestDelegate _)
        {
        }

        public async Task InvokeAsync(HttpContext context, IResponseNumber responseNumber)
            => await context.Response.WriteAsync($"{responseNumber.ResponseNumber(ToUInt16(context.Request.Query["number"]))}");
    }
}
