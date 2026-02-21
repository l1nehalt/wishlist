using Microsoft.EntityFrameworkCore;
using wishlist.Persistence.Models;

namespace wishlist.Persistence;

public class WishListDbContext(DbContextOptions<WishListDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    public DbSet<WishItem> WishItems { get; set; }
    
    public DbSet<Category> Categories { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
    {
        modelConfigurationBuilder.Properties<Guid>().HaveConversion<string>();
    }
    
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
                .HasForeignKey(x => x.CategoryId)
                .IsRequired(false);

        });

        modelBuilder.Entity<WishItem>(withItem =>
        {
            withItem.Property(x => x.Link)
                .IsRequired(false);

            withItem.Property(x => x.Description)
                .IsRequired(false);
        });
    }
}