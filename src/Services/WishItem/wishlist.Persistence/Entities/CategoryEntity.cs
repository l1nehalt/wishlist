using System.ComponentModel.DataAnnotations;

namespace wishlist.Infrastructure.Entities;

public class CategoryEntity
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    public List<WishItemEntity> WishItems { get; set; } = [];
}