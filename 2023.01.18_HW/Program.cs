var app = WebApplication.CreateBuilder(args).Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
