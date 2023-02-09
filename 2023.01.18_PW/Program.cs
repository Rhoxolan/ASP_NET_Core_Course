WebApplication app = WebApplication.CreateBuilder(args).Build();
ulong num;

app.Use(async (context, next) =>
{
    //Добавить потом обработку ошибок, попробовать с трай парсе
    //Попробовать юинт128
    num = Convert.ToUInt64(context.Request.Query["number"]);
    if(num == 0 || num == 1)
    {
        await context.Response.WriteAsync(num.ToString());
    }
    else
    {
        await next.Invoke();
    }
});

app.Run();
