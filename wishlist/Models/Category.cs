using System.ComponentModel.DataAnnotations;

namespace wishlist.Models;

public class Category
{
    public Guid Id { get; set; }
    
    [MaxLength(50)]
    public string? Title { get; set; }

    public List<WishItem> WishItems { get; set; } = [];
}