using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using WebAppFruitable.Model;
using WebAppFruitable.Repository;
using WebAppFruitable.VnPayment;
using WebAppFruitables.Services.Mail;
using WebApplication1.VnPayment;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<FruitableContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("Fruitables"))
);

builder.Services.AddHttpContextAccessor();
builder.Services.Configure<VnPaymentRequest>(builder.Configuration.GetSection("Payments:VnPayment"));
builder.Services.AddMvc();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(p =>
    {
        p.LoginPath = "/auth/login";
        p.LogoutPath = "/auth/logout";
        p.AccessDeniedPath = "/auth/denied";
        p.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    });

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<FruitableContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<VnPaymentService>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<SiteProvider>();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "dashboard", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");
app.UseAuthentication();
app.UseAuthorization();
app.Run();