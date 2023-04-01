using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.AutoMapperProfiles.CategoryProdiles;
using OnlineShop.AutoMapperProfiles.PhotoProfiles;
using OnlineShop.AutoMapperProfiles.ProductProfiles;
using OnlineShop.AutoMapperProfiles.RoleProfiles;
using OnlineShop.AutoMapperProfiles.UserProfiles;
using OnlineShop.Data;
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
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<User, IdentityRole>()
	.AddEntityFrameworkStores<ShopDbContext>();
string connStr = builder.Configuration.GetConnectionString("shopDB");
builder.Services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(connStr));


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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
