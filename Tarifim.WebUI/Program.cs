using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarifim.Business.Managers;
using Tarifim.Business.Services;
using Tarifim.Data.Context;
using Tarifim.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TarifimContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IFoodService, FoodManager>();

builder.Services.AddDataProtection();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();//


app.MapControllerRoute(
    name: "areas",
    pattern: ("{area:exists}/{controller=Dashboard}/{action=Index}/{id?}")
    );

app.MapControllerRoute(
    name: "default",
    pattern: ("{controller=home}/{action=index}/{id?}")
    );


app.Run();
