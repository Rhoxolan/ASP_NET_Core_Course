using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.AutoMapperProfiles.CategoryProdiles;
using OnlineShop.AutoMapperProfiles.PhotoProfiles;
using OnlineShop.AutoMapperProfiles.ProductProfiles;
using OnlineShop.AutoMapperProfiles.RoleProfiles;
using OnlineShop.AutoMapperProfiles.UserProfiles;
using OnlineShop.Data;
using OnlineShop.Infrastructure.ModelBinderProviders;
using OnlineShop.Models.ViewModels.AccountViewModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(CategoryProfile),
	typeof(CreateCategoryProfile),
	typeof(EditCategoryProfile),
	typeof(ProductProfile),
	typeof(CreateProductProfile),
	typeof(EditProductProfile),
	typeof(PhotoProfile),
	typeof(CreatePhotoProfile),
	typeof(EditPhotoProfile),
	typeof(RegisterViewModel),
	typeof(UserProfile),
	typeof(CreateUserProfile),
	typeof(EditUserProfile),
	typeof(ChangePasswordProfile),
	typeof(RoleProfile),
	typeof(ChangeRoleProfile)
	);

// Add services to the container.
var configurations = builder.Configuration;
builder.Services.AddControllersWithViews(opt =>
{
	opt.ModelBinderProviders.Insert(0, new CartModelBinderProvider());
});
builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
	// Есть вариант добавить пользовательский валидатор - https://stackoverflow.com/questions/47988003/how-to-customize-asp-net-identity-core-username-to-allow-special-characters-and
	opt.User.AllowedUserNameCharacters += "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ ()";
	opt.User.RequireUniqueEmail = false;
}).AddEntityFrameworkStores<ShopDbContext>();
string connStr = builder.Configuration.GetConnectionString("shopDB");
builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(connStr));
builder.Services.AddAuthentication().AddGoogle(options =>
{
	IConfigurationSection googleSection = configurations.GetSection("Authentication:Google");
	options.ClientId = googleSection["ClientId"];
	options.ClientSecret = googleSection["ClientSecret"];
});
builder.Services.AddAuthorization(option =>
{
	option.AddPolicy("ApplicationPolicy", policy =>
	{
		policy.RequireClaim("App", "Online Shop");
		policy.RequireRole("Admin", "Manager");
	});
});
//builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "productsDefault",
	pattern: "{category}",
	defaults: new { controller = "Home", action = "Index" }
	);

app.MapControllerRoute(
	name: "productsPages",
	pattern: "{category}/{page}",
	defaults: new { controller = "Home", action = "Index" }
	);

app.Run();
