using Microsoft.EntityFrameworkCore;
using WebApiGraphql.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<WebStoreContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("WebAppGraphql"))
);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseStaticFiles();
app.Run();
