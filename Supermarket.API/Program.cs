using JNogueira.Logger.Discord;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Context;
using Supermarket.API.Entities;
using Supermarket.API.Interfaces;
using Supermarket.API.Interfaces.Repository;
using Supermarket.API.Interfaces.Services;
using Supermarket.API.Repositories;
using Supermarket.API.Services;
using Supermarket.API.Services.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServices<Product>, ProductServices>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
builder.Services.AddScoped<ICacheServices<Product>, CacheProduct>();
builder.Services.AddScoped<SupermarketContext>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
}); // Config. Cache

var connectionString = builder.Configuration.GetConnectionString("Supermarket");

builder.Services.AddDbContext<SupermarketContext>(options =>
{
    options.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information);
}); // Config. DB

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var httpContext = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();

    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

    loggerFactory.AddDiscord(new DiscordLoggerOptions(app.Configuration["DiscordWebhookUrl"])
    {
        ApplicationName = "SupermarketAPI",
        EnvironmentName = app.Environment.EnvironmentName,
        UserName = "Vigia"
    }, httpContext);
}

app.Run();
