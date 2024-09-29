using Microsoft.EntityFrameworkCore;
using WebAppAuthentication.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<KoiContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("Koi"))
);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.UseRouting();
app.UseAuthorization();
app.Run();