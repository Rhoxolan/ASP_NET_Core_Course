var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => $"Hello! Today is {DateTime.Now.DayOfYear} day of the year.");
app.Run();