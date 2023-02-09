using _2023._01._18_PW;

WebApplication app = WebApplication.CreateBuilder(args).Build();

//Разнести первый Middleware на подклассы
//Проверить корректность
//Создать методы расширения

app.Map("/", () => "Hello!");

app.Map("/fibonacci", appbuilder =>
{
    appbuilder.UseMiddleware<ErrorHandlingMiddleware>();
    appbuilder.UseMiddleware<FirstFibonacciNumberMiddleware>();
    appbuilder.UseMiddleware<FibonacciMiddleware>();
});

//app.Map("/fibonacci", appbuilder =>
//{
//    appbuilder.Use(async (context, next) =>
//    {
//        if (!ushort.TryParse(context.Request.Query["number"], out ushort num))
//        {
//            context.Response.StatusCode = 405;
//            await next.Invoke();
//            return;
//        }
//        if (num == 0 || num == 1)
//        {
//            await context.Response.WriteAsync(num.ToString());
//        }
//        else
//        {
//            await next.Invoke();
//        }
//    });

//    appbuilder.Use(async (context, next) =>
//    {
//        if (context.Response.StatusCode == 405)
//        {
//            await context.Response.WriteAsync("Number is uncorrect");
//            return;
//        }
//        await next.Invoke();
//        if (context.Response.StatusCode == 405)
//        {
//            await context.Response.WriteAsync("Number is uncorrect");
//        }
//    });

//    appbuilder.Use(async (HttpContext context, RequestDelegate next) => //Типы данных параметров функции указаны явно из-за необходимости явно определить, какая перегрузка метода Use используется.
//    {
//        ushort num = Convert.ToUInt16(context.Request.Query["number"]);
//        try
//        {
//            List<UInt128> fl = new()
//        {
//            0, 1
//        };
//            for (int i = 0; i < (num - 1); i++)
//            {
//                fl.Add(fl[^1] + fl[^2]);
//            }
//            await context.Response.WriteAsync(fl[^1].ToString());
//        }
//        catch
//        {
//            context.Response.StatusCode = 405;
//        }
//    });
//});

app.Run();
