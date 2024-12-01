using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

// builder.Services.AddDbContext<KoiContext>(
//     p => p.UseSqlServer(builder.Configuration.GetConnectionString("Koi"))
// );

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(p =>
{
    p.LoginPath = "/auth/login";
    p.LogoutPath = "/auth/logout";
    p.AccessDeniedPath = "/auth/denied";
    p.ExpireTimeSpan = TimeSpan.FromDays(30);
});
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "dashboard", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");

app.Run();