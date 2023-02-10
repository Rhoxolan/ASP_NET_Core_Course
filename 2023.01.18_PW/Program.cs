using _2023._01._18_PW;

WebApplication app = WebApplication.CreateBuilder(args).Build();

app.Map("/", () => "Hello!");

app.Map("/fibonacci", appbuilder =>
{
    appbuilder.UseMiddleware<ErrorHandlingMiddleware>();
    appbuilder.UseMiddleware<QueryCheckerMiddleware>();
    appbuilder.UseMiddleware<QueryNumberCheckerMiddleware>();
    appbuilder.UseMiddleware<FirstFibonacciNumberMiddleware>();
    appbuilder.UseMiddleware<FibonacciMiddleware>();
});

app.Run();
