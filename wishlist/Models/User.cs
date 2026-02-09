using System.ComponentModel.DataAnnotations;

namespace wishlist.Models;

public class User
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public string? Name { get; set; }
    
    [MaxLength(200)]
    public string? Email { get; set; }
    
    [MaxLength(100)]
    public string? Password { get; set; }
    
    public List<WishItem> WishItems { get; set; } = [];
}