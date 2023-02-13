using _2023._01._20_PW;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IResponseNumber, FibonacciResponse>();

var app = builder.Build();

app.Map("/", () => "Hello!");

app.Map("/number", appbuilder =>
{
    appbuilder.UseMiddleware<ErrorHandlingMiddleware>();
    appbuilder.UseMiddleware<QueryCheckerMiddleware>();
    appbuilder.UseMiddleware<QueryNumberCheckerMiddleware>();
    appbuilder.UseMiddleware<ResponseNumberMiddleware>();
});

app.Run();
