using _2023._02._13_PW.Constraints;
using Microsoft.AspNetCore.Builder;
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

//Примечание: чем более специфичней маршрут - тем выше он расположен

app.MapControllerRoute(
    name: "newOrderRoute", //Task 1
    pattern: "newOrder",
    defaults: new { controller = "Shop", action = "Buy" });

app.MapControllerRoute(
    name: "home", //Task 2
    pattern: "{controller:regex(^H.*)=Home}/{action:maxlength(6)=index}/{id?}");

app.MapControllerRoute(
    name: "usersettingsNewRoute", //Task 3
    pattern: "usersettings/{id:range(1,999)}",
    defaults: new { controller = "User", action = "Settings" });

app.MapControllerRoute(
    name: "userDefaultRoute",
    pattern: "user/{action}/{id?}",
    defaults: new { controller = "User" }
    );

app.MapControllerRoute(
    name: "adminDefaultRoute", //Task 4
    pattern: "admin/{action}",
    defaults: new { controller = "Admin" }, //Примечание - необходимо указывать значение сегмента по умолчанию, если в паттерне маршрута используется статический сегмент.
    constraints: new { action = new EndsSetupConstraint() });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller:regex(^[^HAU].*)}/{action=Index}/{id?}"); //Ограничиваем в дефолтном маршруте работу с контроллерам "Home, Admin и User, так как для них прописаны ограничения в других методах"

app.Run();
