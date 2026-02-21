using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wishlist.Infrastructure.Entities;

namespace wishlist.Infrastructure.Configurations;

public class WishItemsConfiguration : IEntityTypeConfiguration<WishItemEntity>
{
    public void Configure(EntityTypeBuilder<WishItemEntity> builder)
    {
        
    }
}