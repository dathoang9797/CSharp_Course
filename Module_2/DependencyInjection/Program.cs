using Microsoft.EntityFrameworkCore;
using DependencyInjection.Models;

var builder = WebApplication.CreateBuilder(args);

//DI (dependency injection) Tăng hiệu suất

//==========AddTransient=============
// Mỗi lần request sẽ khởi tạo trong constructor
// Không kiểm tra, có bao nhiêu lớp khởi tạo bấy nhiêu lần
// builder.Services.AddTransient<CategoryRepository>();
// builder.Services.AddTransient<ProductRepository>();
//===================================

//==========AddScoped=============
// Mỗi lần request sẽ khởi tạo trong constructor
// Kiểm tra lớp đã khởi tạo hay chưa nếu chưa sẽ khởi tạo 1 lần
// builder.Services.AddScoped<CategoryRepository>();
// builder.Services.AddScoped<ProductRepository>();
//===================================

//==========AddSingleton=============
// Khởi tạo một lần duy nhất tương đương khái niệm static,
// dù có nhiều controller, không nên dùng
// builder.Services.AddSingleton<CategoryRepository>();
//===================================


// builder.Services.AddTransient<StoreContext>(); //Khởi tạo constructor 2 lần
// builder.Services.AddScoped<StoreContext>(); //Khởi tạo constructor 1 lần
builder.Services.AddTransient<SiteProvider>();

//Entity framwork xử lý như thế nào?
builder.Services.AddDbContext<StoreContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("Euro"))
);






// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();