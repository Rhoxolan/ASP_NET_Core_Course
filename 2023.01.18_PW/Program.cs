using _2023._01._18_PW;

WebApplication app = WebApplication.CreateBuilder(args).Build();

//Удалить классы, попробовать с методами, переменную не передавать а каждый раз забирать из запроса.

app.Use(async (context, next) =>
{
    //Добавить потом обработку ошибок, попробовать с трай парсе
    //Попробовать юинт128
    ulong num = Convert.ToUInt64(context.Request.Query["number"]);
    if (num == 0 || num == 1)
    {
        await context.Response.WriteAsync(num.ToString());
    }
    else
    {
        await next.Invoke(context, num);;
    }
});

app.UseMiddleware<FibonacciNumberMiddleware>();

app.Run();
