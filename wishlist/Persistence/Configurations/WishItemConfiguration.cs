using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wishlist.Persistence.Models;

namespace wishlist.Persistence.Configurations;

public class WishItemConfiguration : IEntityTypeConfiguration<WishItem>
{
    public void Configure(EntityTypeBuilder<WishItem> builder)
    {
        
    }
}