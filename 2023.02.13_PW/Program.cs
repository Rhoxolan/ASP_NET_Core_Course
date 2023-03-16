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

app.MapControllerRoute(
	name: "newOrderRoute", //Task 1
	pattern: "newOrder",
	defaults: new { controller = "Shop", action = "Buy" });

app.Run();
