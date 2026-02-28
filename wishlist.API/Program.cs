using Microsoft.EntityFrameworkCore;
using wishlist.Application.Interfaces;
using wishlist.Application.Services;
using wishlist.Controllers;
using wishlist.Domain.Abstractions;
using wishlist.Infrastructure;
using wishlist.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<WishListDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention();
});

builder.Services.AddScoped<IWishItemsRepository, WishItemsRepository>();
builder.Services.AddScoped<IWishItemsService, WishItemsService>();
builder.Services.AddScoped<WishItemsController>();

var app = builder.Build();

app.MapControllers();
app.UseSwagger(); 
app.UseSwaggerUI();

app.Run();

