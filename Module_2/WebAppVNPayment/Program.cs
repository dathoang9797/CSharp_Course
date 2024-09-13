using Microsoft.EntityFrameworkCore;
using WebAppVNPayment;
using WebAppVNPayment.Models;
using WebAppVNPayment.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StoreContext>(p => p.UseSqlServer(builder.Configuration.GetConnectionString("Store")));
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<VnPaymentRequest>(builder.Configuration.GetSection("Payments:VnPayment"));

builder.Services.AddScoped<VnPaymentService>();
builder.Services.AddScoped<SiteProvider>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapDefaultControllerRoute();
app.UseStaticFiles();
app.Run();