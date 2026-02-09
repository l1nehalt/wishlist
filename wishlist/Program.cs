using Microsoft.EntityFrameworkCore;
using wishlist;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention();
});

var app = builder.Build();

app.UseSwagger(); 
app.UseSwaggerUI();

app.Run();

