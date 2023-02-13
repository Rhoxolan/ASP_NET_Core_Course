using _2023._01._20_PW.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddResponseNumberService();

var app = builder.Build();
app.Map("/", () => "Hello!");
app.Map("/number", appbuilder => appbuilder.UseResponseNumberMiddelware());

app.Run();
