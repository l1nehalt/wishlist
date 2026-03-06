using System.ComponentModel.DataAnnotations;

namespace wishlist.Infrastructure.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public string? Name { get; set; }
    
    [MaxLength(200)]
    public string? Email { get; set; }
    
    [MaxLength(100)]
    public string Password { get; set; } = string.Empty;
    
    public List<WishItemEntity> WishItems { get; set; } = [];
}