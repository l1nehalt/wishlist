using System.ComponentModel.DataAnnotations;

namespace wishlist.Persistence.Models;

public class WishItem
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    public double Price { get; set; }
    
    [MaxLength(1000)]
    public string? Link { get; set; }
    
    public User? User { get; set; }
    
    public Guid UserId { get; set; }
    
    public Category? Category { get; set; }
    
    public Guid? CategoryId { get; set; }
}