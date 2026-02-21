using Microsoft.EntityFrameworkCore;
using wishlist.Infrastructure.Entities;

namespace wishlist.Infrastructure;

public class WishListDbContext(DbContextOptions<WishListDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }
    
    public DbSet<WishItemEntity> WishItems { get; set; }
    
    public DbSet<CategoryEntity> Categories { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
    {
        modelConfigurationBuilder.Properties<Guid>().HaveConversion<string>();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(user =>
        {
            user.HasKey(x => x.Id);
            
            user.HasMany(x => x.WishItems)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        });

        modelBuilder.Entity<CategoryEntity>(category =>
        {
            category.HasKey(x => x.Id);
            
            category.HasMany(x => x.WishItems)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired(false);

        });

        modelBuilder.Entity<WishItemEntity>(withItem =>
        {
            withItem.Property(x => x.Link)
                .IsRequired(false);

            withItem.Property(x => x.Description)
                .IsRequired(false);
        });
    }
}