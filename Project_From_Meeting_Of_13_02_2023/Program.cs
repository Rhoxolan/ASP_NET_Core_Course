using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "pib",
	pattern: "{controller}/{action}/{name}/{age}",
	constraints: new { age = new IntRouteConstraint() });

app.MapControllerRoute(
	name: "buy",
	pattern: "admin",
	defaults: new { controller = "Admin", action = "Edit" });

app.MapControllerRoute(
	name: "buy",
	pattern: "{controller:regex(^H\\d?)}/ua-{action}/{id?}",
	defaults: new { controller = "Admin", action = "Edit" });

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
