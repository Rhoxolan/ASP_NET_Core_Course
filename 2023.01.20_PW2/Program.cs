using _2023._01._20_PW2.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDrinkService();

var app = builder.Build();
app.Map("/", () => "Hello!");
app.Map("/drink", appbuilder => appbuilder.UseDrinkMiddelware());
app.Run();
