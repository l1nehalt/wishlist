namespace wishlist.Domain.Models;

public class WishItem
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public double Price { get; set; }
    
    public string? Link { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid? CategoryId { get; set; }
}