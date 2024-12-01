using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebAppAuthentication.Model;
using WebAppFruitables.Models;
using WebAppFruitables.Services.Mail;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FruitableContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("Fruitables"))
);
builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(p =>
{
    p.LoginPath = "/auth/login";
    p.LogoutPath = "/auth/logout";
    p.AccessDeniedPath = "/auth/denied";
    p.ExpireTimeSpan = TimeSpan.FromDays(30);
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<SiteProvider>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.UseAuthentication();
app.UseAuthorization();
app.Run();