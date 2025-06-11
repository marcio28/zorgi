using Microsoft.EntityFrameworkCore;
using Zorgi.Api.Configuration;
using Zorgi.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.WebApiConfig();

builder.Services.ResolveDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMvcConfig();

app.UseAuthorization();

app.MapControllers();

app.Run();
