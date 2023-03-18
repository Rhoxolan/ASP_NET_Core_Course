using BigProject.Data.Entities;
using CatsProject.AutoMapperProfiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(CatProfile), typeof(BreedProfile));
builder.Services.AddDbContext<CatContext>(options =>
options.UseSqlServer(
	builder.Configuration.GetConnectionString("CatsDb")
	?? throw new InvalidOperationException("Connection string not set!")));

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	await SeedData.Initialize(serviceProvider,
		app.Environment);
}
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

app.MapControllers();

app.Run();
