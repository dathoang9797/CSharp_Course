using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebAppProduct.Models;
using WebAppProduct.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Notification>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ProjectContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("Laptop"))
);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(p =>
    {
        p.LoginPath = "/auth/login";
        p.LogoutPath = "/auth/logout";
        p.AccessDeniedPath = "/auth/denined";
        p.Cookie.Name = "cebnetvn";
        p.ExpireTimeSpan = TimeSpan.FromDays(30);
    });

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.UseRouting();
app.UseAuthorization();
app.Run();