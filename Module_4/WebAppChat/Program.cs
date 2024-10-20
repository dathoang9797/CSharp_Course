using Microsoft.AspNetCore.Authentication.Cookies;
using WebAppChat.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(p =>
{
    p.LoginPath = "/auth/login";
    p.LogoutPath = "/auth/logout";
    p.AccessDeniedPath = "/auth/denined";
    p.Cookie.Name = "cebnetvn";
    p.ExpireTimeSpan = TimeSpan.FromDays(30);
});

builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.AddMvc();

var app = builder.Build();
app.MapHub<ChatHub>("/chathub");
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();