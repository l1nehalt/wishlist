using System.ComponentModel.DataAnnotations;

namespace wishlist.Infrastructure.Entities;

public class WishItemEntity
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    public double Price { get; set; }
    
    [MaxLength(1000)]
    public string? Link { get; set; }
    
    public UserEntity? User { get; set; }
    
    public Guid UserId { get; set; }
    
    public CategoryEntity? Category { get; set; }
    
    public Guid? CategoryId { get; set; }
}