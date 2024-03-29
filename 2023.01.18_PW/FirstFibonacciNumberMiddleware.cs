﻿namespace _2023._01._18_PW
{
    public class FirstFibonacciNumberMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstFibonacciNumberMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ushort num = Convert.ToUInt16(context.Request.Query["number"]);
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
