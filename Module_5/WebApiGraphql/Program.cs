using GraphQL.Server;
using Microsoft.EntityFrameworkCore;
using WebApiGraphql.Models;
using WebApiGraphql.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebStoreContext>(
    p => p.UseSqlServer(builder.Configuration.GetConnectionString("WebAppGraphql"))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CategoryMutation>();
builder.Services.AddScoped<CategoryQuery>();
builder.Services.AddScoped<AppSchema>();
builder.Services.AddGraphQL().AddSystemTextJson();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGraphQL<AppSchema>();
app.UseGraphQLGraphiQL("/ui/graphql");
app.MapControllers();
app.Run();
