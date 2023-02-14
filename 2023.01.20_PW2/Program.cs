using _2023._01._20_PW2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IDrink, Tea>();
builder.Services.AddTransient<IDrink, Coffe>();
builder.Services.AddTransient<IDrink, MineralWater>();
builder.Services.AddTransient<DrinkService>();

var app = builder.Build();

app.Map("/", () => "Hello!");

app.Map("/drink", appbuilder =>
{
    appbuilder.UseMiddleware<ErrorHandlingMiddleware>();
    appbuilder.UseMiddleware<QueryCheckerMiddleware>();
    appbuilder.UseMiddleware<QueryDrinkCheckerMiddleware>();
    appbuilder.UseMiddleware<DrinkMiddelware>();
});

app.Run();
