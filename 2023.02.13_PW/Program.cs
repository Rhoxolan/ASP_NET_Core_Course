using _2023._02._13_PW.Constraints;

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

//Примечание: чем более специфичней маршрут - тем выше он расположен

//Task 1
app.MapControllerRoute(
	name: "newOrderRoute",
	pattern: "newOrder",
	defaults: new { controller = "Shop", action = "Buy" });

//Task 2
app.MapControllerRoute(
	name: "homeDefaultRoute",
	pattern: "home/{action:maxlength(6)}/{id?}",
	defaults: new { controller = "Home" }); //Примечание - необходимо указывать значение сегмента по умолчанию, если в паттерне маршрута используется статический сегмент.

//Task 3
app.MapControllerRoute(
	name: "usersettingsNewRoute",
	pattern: "usersettings/{id:range(1,999)}",
	defaults: new { controller = "User", action = "Settings" });

//Task 4
app.MapControllerRoute(
	name: "adminDefaultRoute",
	pattern: "admin/{action}",
	defaults: new { controller = "Admin" },
	constraints: new { action = new EndsSetupConstraint() });

app.Run();
