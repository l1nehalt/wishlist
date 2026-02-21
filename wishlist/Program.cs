using Microsoft.EntityFrameworkCore;
using wishlist;
using wishlist.Controllers;
using wishlist.Persistence;
using wishlist.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<WishListDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention();
});

builder.Services.AddScoped<WishItemService>();
builder.Services.AddScoped<WishItemController>();

var app = builder.Build();

app.MapControllers();
app.UseSwagger(); 
app.UseSwaggerUI();

app.Run();

