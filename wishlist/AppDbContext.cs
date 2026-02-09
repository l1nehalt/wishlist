using Microsoft.EntityFrameworkCore;
using wishlist.Models;

namespace wishlist;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<WishItem> WishItems { get; set; }
    
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(x => x.Id);

            user.HasMany(x => x.WishItems)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        });

        modelBuilder.Entity<Category>(category =>
        {
            category.HasKey(x => x.Id);

            category.HasMany(x => x.WishItems)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

        });
    }
}