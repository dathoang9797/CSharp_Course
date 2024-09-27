using Microsoft.EntityFrameworkCore;
using WebAppAuthentication.Model;
using WebAppFruitables.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<FruitableContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("Fruitables"))
);
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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.UseRouting();
app.UseAuthorization();
app.Run();