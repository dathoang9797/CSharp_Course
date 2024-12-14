using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using WebAppStore.Model;
using WebAppStore.Services;
using WebAppStore.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<IdentityOptions>(p =>
{
    p.Password.RequireNonAlphanumeric = false;
    p.Password.RequireUppercase = false;
    p.Password.RequireLowercase = false;
    p.Password.RequireUppercase = false;
    p.Password.RequireDigit = false;
    p.Password.RequiredUniqueChars = 1;
    p.Password.RequiredLength = 3;
});

builder.Services.AddAuthentication(IdentityConstants.BearerScheme).AddGoogle(p =>
{
    p.SignInScheme = IdentityConstants.ExternalScheme;
    p.SaveTokens = true;
    p.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? "";
    p.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? "";
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

// Add services to the container.
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddDbContext<StoreContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("Store") ?? ""));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<StoreContext>()
    .AddDefaultTokenProviders();

builder.Services.AddMvc();

var app = builder.Build();
app.MapControllerRoute(name: "dashboard", pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");
app.MapDefaultControllerRoute();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();