using Microsoft.EntityFrameworkCore;
using Euro.Models;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EuroContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("Euro"))
);
// builder.Services.AddScoped<TeamRepository>();
// builder.Services.AddScoped<ClubRepository>();
builder.Services.AddTransient<SiteProvider>();
builder.Services.AddMvc();
// builder.Services.AddRazorPages();
// builder.Services.AddServerSideBlazor();
// builder.Services.AddSingleton<WeatherForecastService>();

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
// app.UseHttpsRedirection();
// app.UseRouting();
// app.MapBlazorHub();
// app.MapFallbackToPage("/_Host");

app.Run();