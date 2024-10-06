using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebKoi.Model;
using WebKoi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Notification>();
builder.Services.AddSignalR();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<KoiContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("Koi"))
);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(p => { p.LoginPath = "/auth/login"; })
    .AddGoogle(p =>
    {
        p.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? string.Empty;
        p.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? string.Empty;
    });

var app = builder.Build();
app.MapHub<Notification>(pattern: "/notify");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.UseRouting();
app.UseAuthorization();
app.Run();