using InventoryServiceWebAPI.Data;
using Microsoft.EntityFrameworkCore;
// Add this using directive for NSwag OpenAPI support
using NSwag.AspNetCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Adding Entity Framework
//builder.Services.AddDbContext<InventoryDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure()
    ));

// Make sure you have installed the NSwag.AspNetCore NuGet package for this extension method to be available
builder.Services.AddOpenApiDocument(configure =>
{
    configure.Title = "Inventory Service Web API";
    configure.Version = "v1";
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseOpenApi();
app.UseSwaggerUi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
