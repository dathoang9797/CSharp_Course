using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebAppAuthentication.Model;
using WebAppFruitables.Models;
using WebAppFruitables.Services.Mail;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FruitableContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("Fruitables"))
);

var secretKey = builder.Configuration.GetValue<string>("Jwt:SecretKey") ?? "";

builder.Services.AddAuthentication(p =>
{
    p.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    p.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(p =>
{
    p.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
        ValidIssuer = "cse.net.vn",
        ValidAudience = "cse.net.vn",
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
}).AddCookie(p =>
{
    p.LoginPath = "/auth/login";
    p.LogoutPath = "/auth/logout";
    p.AccessDeniedPath = "/auth/denied";
    p.ExpireTimeSpan = TimeSpan.FromDays(30);
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Default", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());

    options.AddPolicy("Admin", new AuthorizationPolicyBuilder()
        .RequireRole("Admin")
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build());
});

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddScoped<SiteProvider>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Run();