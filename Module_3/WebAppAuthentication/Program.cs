using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebAppAuthentication.Model;
using WebAppAuthentication.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie()
    .AddGoogle(p =>
    {
        p.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        p.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });

builder.Services.AddDbContext<StoreContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("Store")));
builder.Services.AddScoped<MemberRepository>();
// Add services to the container.
builder.Services.AddMvc();

var app = builder.Build();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();